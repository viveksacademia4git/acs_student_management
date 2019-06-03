using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using System.Collections.ObjectModel;


namespace Wpf_ManageStudents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> students;
        string filter = "";
        private bool storeData;
        List<InputName> female = new List<InputName>();
        List<InputName> male = new List<InputName>();
        List<InputName> lastNames = new List<InputName>();
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            students = TestStorage.ReadXml<ObservableCollection<Student>>("StudentsTest.xml");
            if (students == null)
                students = GenerateStudents(200);
            //students = new ObservableCollection<Student>();
            //students = GenerateStudents(20);
            //TestStorage.WriteXml<ObservableCollection<Student>>(students, "StudentsTest.xml");
            Lbx_students.ItemsSource = students;
        }

        private ObservableCollection<Student> GenerateStudents(int cnt)
        {
            var lstInput = TestStorage.ReadXml<List<InputName>>("InputData.xml");
            male = (from n in lstInput where n.cat == "m" select n).ToList();
            female = (from n in lstInput where n.cat == "f" select n).ToList();
            lastNames = (from n in lstInput where n.cat == "l" select n).ToList();
            var lst = new ObservableCollection<Student>();
            for (int i = 0; i < cnt; i++)
            {
                // lst.Add(new Student { id = i, firstName = "fname" + i, lastName = $"lName{i}", hobbies = "the hobbbbbiesss" });    
                Student stu = new Student();
                int forGender = rnd.Next(100);
                int forAge = rnd.Next(21, 31);
                if (forGender < 25)
                {
                    stu = new Student { id = i, firstName = female[rnd.Next(female.Count)].name, lastName = lastNames[rnd.Next(lastNames.Count)].name, hobbies = "the hobbbbbiesss", isFemale = true, birthDate = DateTime.Today.AddYears(-forAge) };

                }
                else
                {
                    stu = new Student { id = i, firstName = male[rnd.Next(male.Count)].name, lastName = lastNames[rnd.Next(lastNames.Count)].name, hobbies = "the hobbbbbiesss", isFemale = false, birthDate = DateTime.Today.AddYears(-forAge) };

                }
                lst.Add(stu);
            }
            return lst;
        }


        private void Btn__add_Click(object sender, RoutedEventArgs e)
        {
            var stud = new Student { firstName = "please edit!!!", lastName = "please edit!!!" };
            students.Add(stud);
            Lbx_students.SelectedItem = stud;
            Lbx_students.ScrollIntoView(stud);

        }

        private void Btn__delete_Click(object sender, RoutedEventArgs e)
        {
            if (Lbx_students.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to be deleted first!", "Error");
                return;
            }

            students.Remove(Lbx_students.SelectedItem as Student);
            Tbx_filter.Text = "";

        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter = Tbx_filter.Text.ToLower();
            if (filter == "")
            {
                Lbx_students.ItemsSource = students;
            }
            else
            {
                var results = from s in students where s.lastName.ToLower().Contains(filter) select s;
                Lbx_students.ItemsSource = results;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Lbx_students.SelectedItem as Student).taskOk = !(Lbx_students.SelectedItem as Student).taskOk;
            storeData = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (storeData)
                TestStorage.WriteXml<ObservableCollection<Student>>(students, "StudentsTest.xml");
        }

        private void Tbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            storeData = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_Quiz_Click(object sender, RoutedEventArgs e)
        {
            var win = new Quiz();
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Hidden;
        }
    }
}
