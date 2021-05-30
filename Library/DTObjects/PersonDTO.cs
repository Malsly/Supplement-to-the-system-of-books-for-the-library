using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Entities.Abs;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DTObjects
{
    public class PersonDTO: IPerson, INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name;
        private string surname;
        private DateTime birthday;
        private Access access;
        private List<PrintedEditionOrderDTO> bookDebt;
        private List<PrintedEditionOrderDTO> takenBook;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }


        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public Access Access
        {
            get { return access; }
            set
            {
                access = value;
                OnPropertyChanged("Access");
            }
        }

        public List<PrintedEditionOrderDTO> BookDebt
        {
            get { return bookDebt; }
            set
            {
                bookDebt = value;
                OnPropertyChanged("BookDebt");
            }
        }

        public List<PrintedEditionOrderDTO> TakenBook
        {
            get { return takenBook; }
            set
            {
                takenBook = value;
                OnPropertyChanged("TakenBook");
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
