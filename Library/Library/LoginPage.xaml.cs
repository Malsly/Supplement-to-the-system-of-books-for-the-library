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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage(Frame frame)
        {
            InitializeComponent();
            AccauntPage accauntPage = new AccauntPage(new AccauntViewModel(frame, new AccauntDTO(), this));
            DataContext = new LoginViewModel(frame, accauntPage, this);
        }
    }
}
