using BL.Impl;
using DTObjects;
using Entities.Abs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace ViewModels
{
    public class AccauntViewModel : INotifyPropertyChanged
    {
        private AccauntService accauntService = new AccauntService();
        private PersonService personService = new PersonService();

        private Frame frame;
        private AccauntDTO accaunt;
        private string alertMessage;
        private List<BookDTO> availableBooks;
        private PersonDTO library;

        private BookDTO selectedAvailableBook;
        private BookDTO selectedTakenBook;
        private BookDTO selectedBookDebt;

        public AccauntViewModel(Frame mainFrame, AccauntDTO accauntDTO) 
        {
            frame = mainFrame;
            accaunt = accauntDTO;
            library = personService.GetAll().Data.FirstOrDefault(pers => pers.Access == Access.Library);
            //GetAvailableBooks();
        }

        public List<BookDTO> GetAvailableBooks() 
        {
            availableBooks = new List<BookDTO>();
            List<PrintedEditionOrderDTO> avialablePREdotionOrders = library.TakenBook;
            foreach (PrintedEditionOrderDTO printedEditionOrderDTO in avialablePREdotionOrders)
            {
                availableBooks.Add(printedEditionOrderDTO.PrintedEdition);
            }
            return availableBooks;
        }
        public BookDTO SelectedAvailableBook
        {
            get { return selectedAvailableBook; }
            set
            {
                selectedAvailableBook = value;
                OnPropertyChanged("SelectedAvailableBook");
            }
        }
        public BookDTO SelectedTakenBook
        {
            get { return selectedTakenBook; }
            set
            {
                selectedTakenBook = value;
                OnPropertyChanged("SelectedTakenBook");
            }
        }
        public BookDTO SelectedBookDebt
        {
            get { return selectedBookDebt; }
            set
            {
                selectedBookDebt = value;
                OnPropertyChanged("SelectedBookDebt");
            }
        }

        public List<BookDTO> AvailableBooks
        {
            get { return availableBooks; }
            set
            {
                availableBooks = value;
                OnPropertyChanged("AvailableBooks");
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

        public string AlertMessage
        {
            get { return alertMessage; }
            set
            {
                alertMessage = value;
                OnPropertyChanged("AlertMessage");
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
