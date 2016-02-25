using System;
using System.Collections.Generic;
using System.Windows;

namespace H6DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HockeyLeague smleague;
        List<HockeyTeam> leagueTeams;
        int index;

        public MainWindow()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            List<String> teams = new List<string>();
            teams.Add("Ilves");
            teams.Add("JYP");
            teams.Add("Kärpät");
            cbbTeams.ItemsSource = teams;

            smleague = new HockeyLeague();
            leagueTeams = smleague.GetTeams();
        }

        private void btnGetSetting_Click(object sender, RoutedEventArgs e)
        {
            // Look at the structure of App.config for help on
            // finding your variable
            btnGetSetting.Content = H6DataBinding.Properties.Settings
                                    .Default.UserName;
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            spLeague.DataContext = leagueTeams;
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (++index >= leagueTeams.Count) index = leagueTeams.Count - 1;
            spLeague.DataContext = leagueTeams[index];
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            if (--index < 0) index = 0;
            spLeague.DataContext = leagueTeams[index];
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            HockeyTeam newTeam = new HockeyTeam();
            leagueTeams.Add(newTeam);
            index = leagueTeams.Count - 1;
            spLeague.DataContext = leagueTeams[index];
        }
    }
}
