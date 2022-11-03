using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuseumWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new museumEntities();
        }

        private void ContactsBtn_Click(object sender, RoutedEventArgs e)
        {
            (new Windows.ContactsWindow()).Show();
        }

        private void ItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            (new Windows.ItemsWindow()).Show();
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            (new Windows.ExportWindow()).Show();
        }
    }
}
