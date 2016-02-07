/*
 * Weekly Task 4
 * Created: 07.02.2016
 * Author: Ruben Laube-Pohto
 */

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

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Pelaaja> players;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            players = new List<Pelaaja>();

            string[] teams =
            {
                "Blues",
                "HIFK",
                "HPK",
                "Ilves",
                "JYP",
                "KalPa",
                "KooKoo",
                "Kärpät",
                "Lukko",
                "Pelicans",
                "SaiPa",
                "Sport",
                "Tappara",
                "TPS",
                "Ässät"
            };

            cmbTeam.ItemsSource = teams;
            UpdateDisplay();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCreate_New_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = tbFirst_Name.Text;
                string lastName = tbLast_Name.Text;
                string team = cmbTeam.Text;
                double transferCost = double.Parse(tbTransfer_Cost.Text);

                players.Add(new Pelaaja(firstName, lastName, team, transferCost));
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateDisplay()
        {
            lbPlayers.ItemsSource = null;
            lbPlayers.ItemsSource = players;
        }
    }
}
