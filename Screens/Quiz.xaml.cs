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
using System.Windows.Shapes;

namespace Wpf_ManageStudents
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        Question question;

        public Quiz()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            question = new Question
            {
                text = "Question text 1",
                answers = new
                List<Answer> {new Answer { text="answer1 q1",status=false}, new Answer { text = "answer1 q2", status = true },
            new Answer { text="answer1 q3",status=false},new Answer { text="answer1 q4",status=false}}
            };

            DataContext = question;
             
        }

        private void ListBox_answers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var answ = (Answer)(sender as ListBox).SelectedItem;
            if (answ.status)
            {
                MessageBox.Show("congrats...Answer correct", "correct", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("sorry...Answer not correct", "Incorrect", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
