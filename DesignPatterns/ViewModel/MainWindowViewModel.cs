using System;
using System.ComponentModel;
using System.Windows.Input;

using GalaSoft.MvvmLight.CommandWpf;

using DesignPatterns.Model;
using DesignPatterns.Validators;

namespace DesignPatterns.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private Database DB = Database.Instance;

        #region Properties

        private string firstname;
        public string Firstname { get => firstname; set { firstname = value; OnPropertyChanged("Firstname"); } }

        private string lastname;
        public string Lastname { get => lastname; set { lastname = value; OnPropertyChanged("Lastname"); } }

        private string birthday;
        public string Birthday { get => birthday; set { birthday = value; OnPropertyChanged("Birthday"); } }

        private string ssn;
        public string SSN { get => ssn; set { ssn = value; OnPropertyChanged("SSN"); } }

        private string output;
        public string Output { get => output; set { output = value; OnPropertyChanged("Output"); } }

        private static ICommand addPerson;
        public ICommand AddPerson 
        { 
            get 
            { 
                if (addPerson == null)
                {
                    addPerson = new RelayCommand(() => {
                        Person p = new Person(new NameValidator(), new NameValidator(), new BirthdayValidator(), new SSNValidator());
                        bool isOK = p.CreatePerson(Firstname, Lastname, Birthday, SSN);
                        if (isOK) { DB.AddData(p); Output = DB.ShowData(); }
                    });
                }

                return addPerson;
            } 
        }

        #endregion

        public MainWindowViewModel()
        {
            Firstname = "";
            Lastname = "";
            Birthday = "";
            SSN = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
