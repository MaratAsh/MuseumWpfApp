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
using System.Windows.Shapes;

namespace MuseumWpfApp.Windows
{
    /// <summary>
    /// Interaction logic for ItemEditWindow.xaml
    /// </summary>
    public partial class ItemEditWindow : Window
    {
        museumEntities _context;
        Action<Item> action;
        public ItemEditWindow(museumEntities context)
        {
            InitializeComponent();
            _context = context;
            action = null;
            DataContext = null;
            ItemAuthor.ItemsSource = _context.Authors.ToList();
            var l = new List<bool>();
            l.Add(true);
            l.Add(false);
            ItemDateAccuracyCB.ItemsSource = l;
        }

        public void setItem(Item item)
        {
            DataContext = item;
        }

        public void setAction(Action<Item> action) { this.action = action; }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (action != null)
            {
                action((Item) DataContext);
                Close();
            }
        }
    }
}
