using System.ComponentModel;

namespace Wpf_ManageStudents_2beDeleted
{
    public class Student : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string hobbies { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler is null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool taskOk_;

        public bool taskOk
        {
            get { return taskOk_; }
            set
            {
                taskOk_ = value;
                OnPropertyChanged("taskOk");
            }
        }
    }
}