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
    /// Interaction logic for ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window
    {
        public static museumEntities _context;
        private int _currentPage;
        private int _maxPage;
        private int _pagination;
        public ItemsWindow()
        {
            InitializeComponent();
            _context = new museumEntities();
            var items = _context.Items.ToList();
            _pagination = 5;
            PaginationSlider.Value = _pagination;
            PaginationSlider.Maximum = items.Count();

            _maxPage = Convert.ToInt32(Math.Ceiling( items.Count() * 1.0 / _pagination));
            _currentPage = 1;
            lastPage.Text = _maxPage.ToString();
            ReloadItems();
        }

        private void ReloadItems()
        {
            currentPage.Text = _currentPage.ToString();
            Items.ItemsSource = _context.Items.ToList().Skip(_pagination * (_currentPage - 1)).Take(_pagination);
        }

        private void LastPageBtn_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPage;
            ReloadItems();
        }

        private void NextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < _maxPage)
            {
                _currentPage++;
                ReloadItems();
            }
        }

        private void FirstPageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage != 1)
            {
                _currentPage = 1;
                ReloadItems();
            }
        }

        private void PrevPageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                ReloadItems();
            }
        }

        private void currentPage_TextChanged(object sender, TextChangedEventArgs e)
        {
            int page;
            if (currentPage.Text == "")
            {
                
            }
            else if (int.TryParse(currentPage.Text, out page) && (page > 0 && page <= _maxPage))
            {
                _currentPage = page;
                ReloadItems();
            }
            else
            {
                currentPage.Text = _currentPage.ToString();
            }
        }

        private void PaginationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _pagination = (int) PaginationSlider.Value;
            if (_context != null)
            {
                _maxPage = Convert.ToInt32(Math.Ceiling(_context.Items.ToList().Count() * 1.0 / _pagination));
                if (_currentPage > _maxPage)
                {
                    _currentPage = _maxPage;
                }
                currentPage.Text = _currentPage.ToString();
                lastPage.Text = _maxPage.ToString();
                ReloadItems();
            }
        }
    }
}
