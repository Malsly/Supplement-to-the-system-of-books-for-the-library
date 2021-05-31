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
    }
}
