using BL.Impl;
using DTObjects;
using Entities.Abs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ViewModels
{
    public class AccauntViewModel : INotifyPropertyChanged
    {
        private AccauntService accauntService = new AccauntService();
        private PersonService personService = new PersonService();
        private PrintedEditionOrderService printedEditionOrderService = new PrintedEditionOrderService();
        private AuthorService authorService  = new AuthorService();
        private BookService bookService = new BookService();

        private Frame frame;
        private object loginPage;
        private AccauntDTO accaunt;

        private PersonDTO library;

        private PrintedEditionOrderDTO selectedAvailableBook;
        private PrintedEditionOrderDTO selectedTakenBook;
        private PrintedEditionOrderDTO selectedBookDebt;
        private ObservableCollection<PrintedEditionOrderDTO> availableBooks = new ObservableCollection<PrintedEditionOrderDTO>();
        private ObservableCollection<PrintedEditionOrderDTO> takenBooks = new ObservableCollection<PrintedEditionOrderDTO>();
        private ObservableCollection<PrintedEditionOrderDTO> debtBooks = new ObservableCollection<PrintedEditionOrderDTO>();
        private Visibility returnBookVisibility;
        private Visibility addBookVisibility;
        private Visibility getBookVisibility;
        private string bookName;
        private string bookRate;
        private string alertMessage;
        private string authorName;
        private string authorSurname;
        private DateTime authorBirthday;


        private RelayCommand spoilBookCommand;
        private RelayCommand getBookCommand;
        private RelayCommand addBookCommand;
        private RelayCommand logoutCommand;
        private RelayCommand returnBookCommand;

        public AccauntViewModel(Frame mainFrame, AccauntDTO accauntDTO, object loginPage) 
        {
            this.frame = mainFrame;
            this.accaunt = accauntDTO;
            this.loginPage = loginPage;
            this.authorBirthday = DateTime.Now;
            UpdateBooksList();
            SetButtonVisability();
        }

        private void SetButtonVisability() 
        {
            if (Accaunt.Person == null)
                return;

            if (Accaunt.Person.Access == Access.Administrator) 
            {
                ReturnBookVisibility = Visibility.Visible;
                AddBookVisibility = Visibility.Visible;
                GetBookVisibility = Visibility.Visible;
                return;
            }
            if (Accaunt.Person.Access == Access.Library)
            {
                ReturnBookVisibility = Visibility.Hidden;
                AddBookVisibility = Visibility.Visible;
                GetBookVisibility = Visibility.Hidden;
                return;
            }
            if (Accaunt.Person.Access == Access.Reader)
            {
                ReturnBookVisibility = Visibility.Visible;
                AddBookVisibility = Visibility.Hidden;
                GetBookVisibility = Visibility.Visible;
                return;
            }
        }

        public void UpdateBooksList() 
        {
            this.library = personService.GetAll().Data.FirstOrDefault(pers => pers.Access == Access.Library);
            ObservableCollection<PrintedEditionOrderDTO> avialablePREdotionOrders = library.TakenBook;
            ObservableCollection<PrintedEditionOrderDTO> availableBooks = new ObservableCollection<PrintedEditionOrderDTO>();
            ObservableCollection<PrintedEditionOrderDTO> takenBooks = new ObservableCollection<PrintedEditionOrderDTO>();
            ObservableCollection<PrintedEditionOrderDTO> debtBooks = new ObservableCollection<PrintedEditionOrderDTO>();

            if (accaunt != null && accaunt.Person != null) 
            {
                accaunt = accauntService.Get(Accaunt.Id).Data;

                foreach (PrintedEditionOrderDTO printedEditionOrderDTO in avialablePREdotionOrders)
                {
                    availableBooks.Add(printedEditionOrderDTO);
                }

                foreach (PrintedEditionOrderDTO printedEditionOrderDTO in accaunt.Person.TakenBook)
                {
                    takenBooks.Add(printedEditionOrderDTO);
                }

                foreach (PrintedEditionOrderDTO printedEditionOrderDTO in accaunt.Person.BookDebt)
                {
                    debtBooks.Add(printedEditionOrderDTO);
                }
            }

            AvailableBooks = availableBooks;
            TakenBooks = takenBooks;
            DeptBooks = debtBooks;
        }

        public PrintedEditionOrderDTO SelectedAvailableBook
        {
            get { return selectedAvailableBook; }
            set
            {
                selectedAvailableBook = value;
                OnPropertyChanged("SelectedAvailableBook");
            }
        }
        public PrintedEditionOrderDTO SelectedTakenBook
        {
            get { return selectedTakenBook; }
            set
            {
                selectedTakenBook = value;
                OnPropertyChanged("SelectedTakenBook");
            }
        }
        public PrintedEditionOrderDTO SelectedBookDebt
        {
            get { return selectedBookDebt; }
            set
            {
                selectedBookDebt = value;
                OnPropertyChanged("SelectedBookDebt");
            }
        }

        public ObservableCollection<PrintedEditionOrderDTO> AvailableBooks
        {
            get { return availableBooks; }
            set
            {
                availableBooks = value;
                OnPropertyChanged("AvailableBooks");
            }
        }

        public ObservableCollection<PrintedEditionOrderDTO> TakenBooks
        {
            get { return takenBooks; }
            set
            {
                takenBooks = value;
                OnPropertyChanged("TakenBooks");
            }
        }

        public ObservableCollection<PrintedEditionOrderDTO> DeptBooks
        {
            get { return debtBooks; }
            set
            {
                debtBooks = value;
                OnPropertyChanged("DeptBooks");
            }
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

        public Visibility ReturnBookVisibility
        {
            get { return returnBookVisibility; }
            set
            {
                returnBookVisibility = value;
                OnPropertyChanged("SelectedAvailableBook");
            }
        }

        public Visibility AddBookVisibility
        {
            get { return addBookVisibility; }
            set
            {
                addBookVisibility = value;
                OnPropertyChanged("SelectedAvailableBook");
            }
        }

        public Visibility GetBookVisibility
        {
            get { return getBookVisibility; }
            set
            {
                getBookVisibility = value;
                OnPropertyChanged("SelectedAvailableBook");
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

        public string AuthorName
        {
            get { return authorName; }
            set
            {
                authorName = value;
                OnPropertyChanged("AuthorName");
            }
        }

        public string AuthorSurname
        {
            get { return authorSurname; }
            set
            {
                authorSurname = value;
                OnPropertyChanged("AuthorSurname");
            }
        }

        public DateTime AuthorBirthday
        {
            get { return authorBirthday; }
            set
            {
                authorBirthday = value;
                OnPropertyChanged("AuthorBirthday");
            }
        }

        public string BookRate
        {
            get { return bookRate; }
            set
            {
                bookRate = value;
                OnPropertyChanged("BookRate");
            }
        }

        public string BookName
        {
            get { return bookName; }
            set
            {
                bookName = value;
                OnPropertyChanged("BookName");
            }
        }
            

        public RelayCommand LogoutCommand
        {
            get
            {
                return logoutCommand ??
                  (logoutCommand = new RelayCommand(obj =>
                  {
                      AlertMessage = "Logout success";
                      frame.Content = loginPage;
                  }));
            }
        }

        public RelayCommand ReturnBookCommand
        {
            get
            {
                return returnBookCommand ??
                  (returnBookCommand = new RelayCommand(obj =>
                  {
                      if (SelectedTakenBook == null)
                      {
                          AlertMessage = "Select book to return";
                          return;
                      }

                      PrintedEditionOrderDTO printedEditionOrderDTO = printedEditionOrderService.Get(SelectedTakenBook.Id).Data;
                      printedEditionOrderDTO.TakenBookId = library.Id;

                      library.TakenBook.Add(printedEditionOrderDTO);

                      personService.Update(library);
                      printedEditionOrderService.Update(printedEditionOrderDTO);

                      UpdateBooksList();
                      AlertMessage = "Return Book success";
                  }));
            }
        }

       
        public RelayCommand GetBookCommand
        {
            get
            {
                return getBookCommand ??
                  (getBookCommand = new RelayCommand(obj =>
                  {

                      if (SelectedAvailableBook == null) 
                      {
                          AlertMessage = "Select book to get";
                          return;
                      }

                      PrintedEditionOrderDTO printedEditionOrderDTO = printedEditionOrderService.Get(SelectedAvailableBook.Id).Data;
                      printedEditionOrderDTO.TakenBookId = Accaunt.Person.Id;
                     
                      Accaunt.Person.TakenBook.Add(printedEditionOrderDTO);
                      
                      personService.Update(Accaunt.Person);
                      printedEditionOrderService.Update(printedEditionOrderDTO);

                      UpdateBooksList();
                      AlertMessage = "Get Book success";
                  }));
            }
        }

        public RelayCommand AddBookCommand
        {
            get
            {
                return addBookCommand ??
                  (addBookCommand = new RelayCommand(obj =>
                  {
                      if (Accaunt.Person.Access == Access.Administrator || Accaunt.Person.Access == Access.Library) 
                      {
                          PrintedEditionOrderDTO newPrintedEditionOrder = null;
                          float.TryParse(BookRate, out float floatRate);
                          PrintedEditionOrderDTO printedEditionOrderDTO = printedEditionOrderService.GetAll().Data.FirstOrDefault(prO => prO.PrintedEdition.Name == BookName);
                          if (printedEditionOrderDTO != null)
                          {
                              BookDTO newBook = new BookDTO()
                              {
                                  Authors = printedEditionOrderDTO.PrintedEdition.Authors,
                                  Name = printedEditionOrderDTO.PrintedEdition.Name,
                                  Rate = printedEditionOrderDTO.PrintedEdition.Rate,
                              };

                              newPrintedEditionOrder = new PrintedEditionOrderDTO()
                              {
                                  EndDate = DateTime.Now,
                                  StartDate = DateTime.Now,
                                  TakenBookId = library.Id,
                                  BookDebtId = null,
                                  PrintedEdition = newBook
                              };
                          }
                          else 
                          {
                              BookDTO newBook = null;
                              AuthorDTO newAuthor = authorService.GetAll().Data.FirstOrDefault(auth => auth.Name == AuthorName && auth.Surname == AuthorSurname);
                              if (newAuthor == null)
                              {
                                  newAuthor = new AuthorDTO { Name = AuthorName, Surname = AuthorSurname, Birthday = AuthorBirthday };
                              }

                              newBook = new BookDTO()
                              {
                                  Authors = new ObservableCollection<AuthorDTO>() { newAuthor },
                                  Name = BookName,
                                  Rate = floatRate,
                              };

                              newPrintedEditionOrder = new PrintedEditionOrderDTO()
                              {
                                  EndDate = DateTime.Now,
                                  StartDate = DateTime.Now,
                                  TakenBookId = library.Id,
                                  BookDebtId = null,
                                  PrintedEdition = newBook
                              };
                          }

                          library.TakenBook.Add(newPrintedEditionOrder);
                          personService.Update(library);
                          UpdateBooksList();
                          AlertMessage = "Add Book success";
                      }
                  }));
            }
        }

        public RelayCommand SpoilBookCommand
        {
            get
            {
                return spoilBookCommand ??
                  (spoilBookCommand = new RelayCommand(obj =>
                  {
                      if (SelectedTakenBook == null && SelectedAvailableBook == null)
                      {
                          AlertMessage = "Select taken book to spoil";
                          return;
                      }

                      PrintedEditionOrderDTO printedEditionOrderDTO = null;

                      if (Accaunt.Person.Access == Access.Administrator)
                      {
                          if (SelectedTakenBook != null) 
                          {
                              printedEditionOrderDTO = printedEditionOrderService.Get(SelectedTakenBook.Id).Data;
                              printedEditionOrderDTO.TakenBookId = null;
                              Accaunt.Person.TakenBook.Remove(Accaunt.Person.TakenBook.FirstOrDefault(c => c.Id == printedEditionOrderDTO.Id));
                              printedEditionOrderDTO.BookDebtId = Accaunt.Person.Id;
                              Accaunt.Person.BookDebt.Add(printedEditionOrderDTO);
                              EndSpoil(printedEditionOrderDTO);
                          }
                          if (SelectedAvailableBook != null)
                          {
                              printedEditionOrderDTO = printedEditionOrderService.Get(SelectedAvailableBook.Id).Data;
                              printedEditionOrderService.Delete(printedEditionOrderDTO);
                              UpdateBooksList();
                              AlertMessage = "Spoil Book success";
                          }
                      }

                      if (SelectedTakenBook != null && Accaunt.Person.Access == Access.Reader)
                      {
                          printedEditionOrderDTO = printedEditionOrderService.Get(SelectedTakenBook.Id).Data;
                          printedEditionOrderDTO.TakenBookId = null;
                          Accaunt.Person.TakenBook.Remove(Accaunt.Person.TakenBook.FirstOrDefault(c => c.Id == printedEditionOrderDTO.Id));
                          printedEditionOrderDTO.BookDebtId = Accaunt.Person.Id;
                          Accaunt.Person.BookDebt.Add(printedEditionOrderDTO);
                          EndSpoil(printedEditionOrderDTO);
                      }

                      if (SelectedAvailableBook != null && Accaunt.Person.Access == Access.Library)
                      {
                          printedEditionOrderDTO = printedEditionOrderService.Get(SelectedAvailableBook.Id).Data;
                          printedEditionOrderService.Delete(printedEditionOrderDTO);
                          UpdateBooksList();
                          AlertMessage = "Spoil Book success";
                      }

                      
                  }));
            }
        }

        private void EndSpoil(PrintedEditionOrderDTO printedEditionOrderDTO)
        {
            personService.Update(library);
            accauntService.Update(Accaunt);
            personService.Update(Accaunt.Person);
            printedEditionOrderService.Update(printedEditionOrderDTO);

            UpdateBooksList();
            AlertMessage = "Spoil Book success";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
