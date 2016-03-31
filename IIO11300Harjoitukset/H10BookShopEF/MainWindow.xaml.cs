using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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

namespace H10BookShopEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookShopEntities ctx;
        ObservableCollection<Book> localBooks;
        ICollectionView view;
        bool isBooks;

        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        private void InitMyStuff()
        {
            ctx = new BookShopEntities();
            ctx.Books.Load();
            localBooks = ctx.Books.Local;

            cbCountries.DataContext = localBooks.Select(n => n.country).Distinct();
            cbCountries.Visibility = Visibility.Visible;

            view = CollectionViewSource.GetDefaultView(localBooks);
        }

        private void btnHaeAsiakkaat_Click(object sender, RoutedEventArgs e)
        {
            var customers = ctx.Customers.ToList();
            dgBooks.DataContext = customers;
            isBooks = false;
        }

        private void btnHaeKirjat_Click(object sender, RoutedEventArgs e)
        {
            dgBooks.DataContext = localBooks;
            isBooks = true;
            cbCountries.SelectedIndex = -1;
        }

        private void btnTallenna_Click(object sender, RoutedEventArgs e)
        {
            // Tallennetaan kantaan
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                tbMessage.Text = ex.Message;
            }
        }

        private void btnUusi_Click(object sender, RoutedEventArgs e)
        {
            // Uusi kirja-olio kontekstiin ja sitten tietokantaan
            Book newBook;
            if (btnUusi.Content.ToString() == "Uusi")
            {
                newBook = new Book();
                newBook.name = "Anna kirjan nimi";
                spBook.DataContext = newBook;
                btnUusi.Content = "Tallenna uusi kantaan";
            }
            else
            {
                newBook = (Book)spBook.DataContext;
                ctx.Books.Add(newBook);
                ctx.SaveChanges();
                btnUusi.Content = "Uusi";
                tbMessage.Text = "Kirja " + newBook.name + " lisätty kantaan!";
            }
        }

        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            // Poistetaan kirja-olio ensin kontekstista ja sitten kannasta
            Book current = (Book)spBook.DataContext;
            var retval = MessageBox.Show("Haluatko varmasti poistaa kirjan " + current.DisplayName,
                "Wanhat kirjat kysyy", MessageBoxButton.YesNo);
            if (retval == MessageBoxResult.Yes)
            {
                ctx.Books.Remove(current);
                ctx.SaveChanges();
            }
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isBooks)
            {
                spBook.DataContext = dgBooks.SelectedItem;
            }
            else
            {
                spCustomer.DataContext = dgBooks.SelectedItem;
            }
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Suodatetaan valinnan mukaan ns. predikaatti-funktiolla
            view.Filter = MyCountryFilter;
        }

        private bool MyCountryFilter(object item)
        {
            if (cbCountries.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return (item as Book).country.Contains(cbCountries.SelectedItem.ToString());
            }
        }

        private void btnGetOrders_Click(object sender, RoutedEventArgs e)
        {
            string msg = "";
            Customer current = (Customer)spCustomer.DataContext;
            msg += string.Format("Asiakkaalla {0} on {1} tilausta:\n",
                current.DisplayName, current.OrderCount);
            foreach (var item in current.Orders)
            {
                msg += string.Format("Tilaus {0} sisältää {1} tilausriviä:\n",
                    item.odate, item.Orderitems.Count);
                Decimal summa = 0;
                foreach (var oitem in item.Orderitems)
                {
                    msg += string.Format("- kirja {0}, {1} kpl\n",
                        oitem.Book.name, oitem.count);
                    summa += oitem.count * oitem.Book.price.Value;
                }
                msg += string.Format("  - tilaus yhteensä {0}\n", summa);
            }
            MessageBox.Show(msg);
        }
    }
}
