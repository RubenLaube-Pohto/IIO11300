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
        private const string FILENAME = "E:\\liiga.xml";
        private List<Pelaaja> players;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            players = new List<Pelaaja>();
            txtStatus.Text = "";

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
            try
            {
                players = Serialization.DeSerialisoiXml(FILENAME);
                txtStatus.Text = "Players loaded from file " + FILENAME;
            }
            catch { }
            UpdateDisplay();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = "Quit";
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

                Pelaaja player = new Pelaaja(firstName, lastName, team, transferCost);

                if (IsInPlayers(ref player))
                {
                    throw new Exception("Player is already in the database.");
                }
                else
                {
                    players.Add(player);
                    UpdateDisplay();
                    txtStatus.Text = "Player added.";
                }
            }
            catch (Exception ex)
            {
                txtStatus.Text = ex.Message;
            }
        }

        private void UpdateDisplay()
        {
            lbPlayers.ItemsSource = null;
            lbPlayers.ItemsSource = players;
        }

        private bool IsInPlayers(ref Pelaaja p1)
        {
            foreach (Pelaaja p2 in players)
            {
                if (p1.FullName == p2.FullName)
                {
                    return true;
                }
            }
            return false;
        }

        private void lbPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
            {
                Pelaaja player = (Pelaaja)((ListBox)sender).SelectedItem;

                tbFirst_Name.Text = player.FirstName;
                tbLast_Name.Text = player.LastName;
                cmbTeam.Text = player.Team;
                tbTransfer_Cost.Text = player.TransferCost.ToString(); 
            }
        }

        private void btnRemove_Player_Click(object sender, RoutedEventArgs e)
        {
            if (lbPlayers.SelectedItem != null)
            {
                players.Remove((Pelaaja)lbPlayers.SelectedItem);
                UpdateDisplay();
                txtStatus.Text = "Player removed.";
            }
            else
            {
                txtStatus.Text = "Can't remove. No player selected.";
            }
        }

        private void btnSave_Player_Click(object sender, RoutedEventArgs e)
        {
            if (lbPlayers.SelectedItem != null)
            {
                try
                {
                    Pelaaja player = (Pelaaja)lbPlayers.SelectedItem;

                    // Tehdään tämä ensin, koska voi epäonnistua. Silloin ei tehdä muitakaan päivityksiä.
                    player.TransferCost = double.Parse(tbTransfer_Cost.Text);
                    player.FirstName = tbFirst_Name.Text;
                    player.LastName = tbLast_Name.Text;
                    player.Team = cmbTeam.Text;

                    UpdateDisplay();
                    txtStatus.Text = "Player saved.";
                }
                catch (Exception ex)
                {
                    txtStatus.Text = ex.Message;
                }
            }
            else
            {
                txtStatus.Text = "Can't save. No player selected.";
            }
        }

        private void btnSave_To_File_Click(object sender, RoutedEventArgs e)
        {
            Serialization.SerialisoiXml(FILENAME, players);
            txtStatus.Text = "Players saved to file " + FILENAME;
        }
    }
}
