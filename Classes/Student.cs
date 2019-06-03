﻿using System;
using System.ComponentModel;

namespace Wpf_ManageStudents
{
    public class Student:INotifyPropertyChanged
    {
        
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string hobbies { get; set; }

        public bool isFemale { get; set; }
        public DateTime birthDate { get; set; }

        private bool taskOk_;
        public bool taskOk
        {
            get { return taskOk_; }
            set
            {
                taskOk_ = value;
                OnPropertyChanged("taskOK");
            }
        }
private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}