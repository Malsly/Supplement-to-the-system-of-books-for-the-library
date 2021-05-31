using BL.Impl;
using DTObjects;
using Entities.Abs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Frame frame;
        private object accauntPage;

        private string signInName;
        private string registryName;
        private string signInPassword;
        private string registryPassword;
        private string personName;
        private string personSurname;
        private string alertMessage;
        private DateTime personBirthday;

        private AccauntDTO accaunt = new AccauntDTO();

        private AccauntService accauntService = new AccauntService();
        private PrintedEditionOrderService printedEditionOrderService = new PrintedEditionOrderService();


        public LoginViewModel(Frame frameMain, object accauntPage1) 
        {
            //PersonDTO libraryPerson = new PersonDTO()
            //{
            //    Access = Access.Library,
            //    Name = "Library",
            //    Surname = "Library",
            //    Birthday = DateTime.Now,
            //    BookDebt = new List<PrintedEditionOrderDTO>(),
            //    TakenBook = new List<PrintedEditionOrderDTO>()
            //};
            //AccauntDTO libraryAccaunt = new AccauntDTO() { Login = "Library", Password = "Library", Person = libraryPerson };
            //accauntService.Add(libraryAccaunt);

            AccauntDTO libraryAccauntFromDB = accauntService.GetAll().Data.Find(a => a.Person.Access == Access.Library);

            AuthorDTO ArmandoLucasCorrea = new AuthorDTO() { Name = "Armando", Surname = "Lucas", Birthday = DateTime.Now };
            AuthorDTO JessKidd = new AuthorDTO() { Name = "Jess", Surname = "Kidd", Birthday = DateTime.Now };
            AuthorDTO MarthaMcPhee = new AuthorDTO() { Name = "Martha", Surname = "McPhee", Birthday = DateTime.Now };
            AuthorDTO MeganMiranda = new AuthorDTO() { Name = "Megan", Surname = "Miranda", Birthday = DateTime.Now };
            AuthorDTO HelenPhillips = new AuthorDTO() { Name = "Helen", Surname = "Phillips", Birthday = DateTime.Now };
            AuthorDTO KristinHarmel = new AuthorDTO() { Name = "Kristin", Surname = "Harmel", Birthday = DateTime.Now };

            BookDTO Daughter = new BookDTO() { Name = "The Daughter's Tale", Rate = 4.5f, Authors = new List<AuthorDTO>() { ArmandoLucasCorrea } };
            BookDTO Himself = new BookDTO() { Name = "Himself", Rate = 4.1f, Authors = new List<AuthorDTO>() { JessKidd } };
            BookDTO GorgeousLies = new BookDTO() { Name = "Gorgeous Lies", Rate = 3.5f, Authors = new List<AuthorDTO>() { JessKidd, MarthaMcPhee } };
            BookDTO Winemaker = new BookDTO() { Name = "The Winemaker’s Wife", Rate = 4.8f, Authors = new List<AuthorDTO>() { JessKidd } };
            BookDTO TheDinnerList = new BookDTO() { Name = "The Dinner List", Rate = 1.9f, Authors = new List<AuthorDTO>() { KristinHarmel } };
            BookDTO NormalPeople = new BookDTO() { Name = "Normal People", Rate = 4.9f, Authors = new List<AuthorDTO>() { HelenPhillips, MeganMiranda } };
            BookDTO Kafka = new BookDTO() { Name = "Kafka on the Shore", Rate = 3.3f, Authors = new List<AuthorDTO>() { ArmandoLucasCorrea, KristinHarmel, JessKidd } };

            List<BookDTO> bookDTOs = new List<BookDTO>()
            {
                Daughter,
                Himself,
                GorgeousLies,
                Kafka,
                Winemaker,
                TheDinnerList,
                NormalPeople,
                NormalPeople,
                Kafka,
                Winemaker,
                Himself,
                GorgeousLies,
                Daughter
            };

            foreach (BookDTO bookDTO in bookDTOs)
            {
                printedEditionOrderService.Add(new PrintedEditionOrderDTO()
                {
                    PrintedEdition = bookDTO,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                });
            }

            List<PrintedEditionOrderDTO> printedEditionOrderDTOs = printedEditionOrderService.GetAll().Data;

            libraryAccauntFromDB.Person.TakenBook = printedEditionOrderDTOs;
            accauntService.Update(libraryAccauntFromDB);

            AccauntDTO libraryAccauntFromDBUpdated = accauntService.GetAll().Data.Find(a => a.Person.Access == Access.Library);


            PersonBirthday = DateTime.Now;
            frame = frameMain;
            accauntPage = accauntPage1;
        }

        public AccauntDTO Accaunt
        {
            get { return accaunt; }
            set
            {
                accaunt = value;
                OnPropertyChanged("Accaunt");
            }
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
                      if (SignInName == null || SignInName == ""
                        || SignInPassword == null || SignInPassword == "")
                      {
                          AlertMessage = "Please fill all sign in fields";
                          return;
                      }

                      List<AccauntDTO> accaunts = accauntService.GetAll().Data;
                      AccauntDTO accauntFromDb = accaunts.FirstOrDefault(pers => pers.Login == SignInName && pers.Password == SignInPassword);
                      if (accauntFromDb == null)
                      {
                          AlertMessage = "Login or password is incorrect";
                          return;
                      }

                      AlertMessage = "Sign in success";
                      (accauntPage as Page).DataContext = new AccauntViewModel(frame, accauntFromDb);
                      frame.Content = accauntPage;
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
                      if (SignInName == null || SignInName == ""
                      || SignInPassword == null || SignInPassword == "")
                      {
                          AlertMessage = "Please fill all sign in fields";
                          return;
                      }
                      List<AccauntDTO> accaunts = accauntService.GetAll().Data;
                      AccauntDTO accauntFromDb = accaunts.FirstOrDefault(pers => pers.Login == SignInName && pers.Password == SignInPassword);
                      if (accauntFromDb == null)
                      {
                          AlertMessage = "Login or password is incorrect";
                          return;
                      }
                      accauntService.Delete(accauntFromDb);
                      
                      AlertMessage = "Accaunt deleted";
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

                      AlertMessage = "You accaunt is registred";
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