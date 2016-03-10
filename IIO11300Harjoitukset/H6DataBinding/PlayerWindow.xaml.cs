using System.Collections.Generic;
using System.Windows;

namespace H6DataBinding
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        List<HockeyPlayer> players;
        int index;

        public PlayerWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        private void InitMyStuff()
        {
            players = TestHockeyBench.Get3Players();
            dgPlayers.ItemsSource = players;
            index = 0;
            SetData();
        }

        private void SetData()
        {
            spLeft.DataContext = players[index];
        }

        private void dgPlayers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((dgPlayers.SelectedIndex > -1) && (dgPlayers.SelectedIndex < players.Count)) 
            {
                index = dgPlayers.SelectedIndex;
                SetData();
            }
        }
    }
}
