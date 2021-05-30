using BL.Impl;
using DTObjects;
using Entities.Abs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string signInName;
        private string registryName;
        private string signInPassword;
        private string registryPassword;
        private string personName;
        private string personSurname;
        private string alertMessage;
        private DateTime personBirthday;

        private PersonService personService = new PersonService();
        private AccauntService accauntService = new AccauntService();

        public LoginViewModel() 
        {
            PersonBirthday = DateTime.Now;
        }

        public string SignInName
        {
            get { return signInName; }
            set
            {
                signInName = value;
                OnPropertyChanged("SignInName");
            }
        }

        public string SignInPassword
        {
            get { return signInPassword; }
            set
            {
                signInPassword = value;
                OnPropertyChanged("SignInPassword");
            }
        }

        public string RegistryName
        {
            get { return registryName; }
            set
            {
                registryName = value;
                OnPropertyChanged("RegistryName");
            }
        }

        public string RegistryPassword
        {
            get { return registryPassword; }
            set
            {
                registryPassword = value;
                OnPropertyChanged("RegistryPassword");
            }
        }

        public string PersonName
        {
            get { return personName; }
            set
            {
                personName = value;
                OnPropertyChanged("PersonName");
            }
        }

        public string PersonSurname
        {
            get { return personSurname; }
            set
            {
                personSurname = value;
                OnPropertyChanged("PersonSurname");
            }
        }

        public DateTime PersonBirthday
        {
            get { return personBirthday; }
            set
            {
                personBirthday = value;
                OnPropertyChanged("PersonBirthday");
            }
        }
        public string AlertMessage
        {
            get { return alertMessage; }
            set
            {
                alertMessage = value;
                OnPropertyChanged("AlertMessage");
            }
        }
        

        private RelayCommand signInCommand;
        private RelayCommand deleteAccauntCommand;
        private RelayCommand registerCommand;


        public RelayCommand SignInCommand
        {
            get
            {
                return signInCommand ??
                  (signInCommand = new RelayCommand(obj =>
                  {
                      
                  }));
            }
        }

        public RelayCommand DeleteAccauntCommand
        {
            get
            {
                return deleteAccauntCommand ??
                  (deleteAccauntCommand = new RelayCommand(obj =>
                  {

                  }));
            }
        }

        public RelayCommand RegisterCommand
        {
            get
            {
                return registerCommand ??
                  (registerCommand = new RelayCommand(obj =>
                  {
                      if (RegistryName == null || RegistryName == ""
                      || RegistryPassword == null || RegistryPassword == ""
                      || PersonName == null || PersonName == ""
                      || PersonSurname == null || PersonSurname == ""
                      || PersonBirthday == null)
                      {
                          AlertMessage = "Please fill all registry fields";
                          return;
                      }

                      List<AccauntDTO> accaunts = accauntService.GetAll().Data;
                      AccauntDTO accauntFromDb = accaunts.FirstOrDefault(pers => pers.Login == RegistryName);
                      if (accauntFromDb != null) 
                      {
                          AlertMessage = "Accaunt with same login is registred. Please try another login";
                          return;
                      }
                      
                      PersonDTO person = new PersonDTO() { Name = PersonName, Surname = PersonSurname, Access = Access.Reader, Birthday = PersonBirthday };
                      AccauntDTO accaunt = new AccauntDTO() { Login = RegistryName, Password = RegistryPassword, Person = person };
                      accauntService.Add(accaunt);

                      List<AccauntDTO> accaunts1 = accauntService.GetAll().Data;

                      List<PersonDTO> persons1 = personService.GetAll().Data;

                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}