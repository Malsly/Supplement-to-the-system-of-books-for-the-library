using DTObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels;

namespace Library
{
    /// <summary>
    /// Interaction logic for AccauntPage.xaml
    /// </summary>
    public partial class AccauntPage : Page
    {
        public AccauntPage(AccauntViewModel accauntViewModel)
        {
            InitializeComponent();
            DataContext = accauntViewModel;
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.authorPopUp.IsOpen = false;
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                AuthorDTO authorDTO = item.Content as AuthorDTO;
                this.authorPopUp.DataContext = authorDTO;
                this.authorPopUp.IsOpen = true;
            }
        }

        private void buttonAddBook_Click(object sender, RoutedEventArgs e)
        {
            this.addBookPopUp.IsOpen = true;
        }

        private void buttonCloseAddBookPopup_Click(object sender, RoutedEventArgs e)
        {
            this.addBookPopUp.IsOpen = false;
        }
    }
}
