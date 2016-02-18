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
using System.Xml;

namespace H5Movies
{
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window
    {
        public Movies2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string file = xdpMovies.Source.LocalPath;
            xdpMovies.Document.Save(file);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (lbMovies.SelectedIndex >= 0)
            {
                lbMovies.SelectedIndex = -1; // -1 kun listasta ei valittuna mitään
                btnCreate.Content = "Tallenna uusi";
            }
            else
            {
                try
                {
                    string file = xdpMovies.Source.LocalPath;

                    XmlDocument doc = xdpMovies.Document;
                    XmlNode root = doc.SelectSingleNode("/Movies");
                    XmlNode newMovie = doc.CreateElement("Movie");

                    XmlAttribute xaName = doc.CreateAttribute("Name");
                    XmlAttribute xaDirector = doc.CreateAttribute("Director");
                    XmlAttribute xaCountry = doc.CreateAttribute("Country");
                    XmlAttribute xaChecked = doc.CreateAttribute("Checked");

                    xaName.Value = txtName.Text;
                    xaDirector.Value = txtDirector.Text;
                    xaCountry.Value = txtCountry.Text;
                    xaChecked.Value = chkIsSeen.IsChecked.ToString();

                    newMovie.Attributes.Append(xaName);
                    newMovie.Attributes.Append(xaDirector);
                    newMovie.Attributes.Append(xaCountry);
                    newMovie.Attributes.Append(xaChecked);

                    root.AppendChild(newMovie);

                    xdpMovies.Document.Save(file);
                    MessageBox.Show("Uusi elokuva lisätty!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    btnCreate.Content = "Lisää uusi";
                    lbMovies.SelectedIndex = lbMovies.Items.Count - 1;
                }
            }
        }
    }
}
