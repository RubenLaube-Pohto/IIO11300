using System.Collections.Generic;
using System.ComponentModel;

namespace H6DataBinding
{
    public static class TestHockeyBench
    {
        public static List<HockeyPlayer> Get3Players()
        {
            List<HockeyPlayer> players = new List<HockeyPlayer>();
            players.Add(new HockeyPlayer("Teemu Selänne", "8"));
            players.Add(new HockeyPlayer("Jarkko Immonen", "26"));
            players.Add(new HockeyPlayer("Ville Peltonen", "16"));
            return players;
        }
    }
    public class HockeyPlayer : INotifyPropertyChanged
    {
        #region VARIABLES
        private string name;
        private string number;
        #endregion
        #region PROPERTIES
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                Notify("Name");
                Notify("NameAndNumber");
            }
        }
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                Notify("Number");
                Notify("NameAndNumber");
            }
        }
        public string NameAndNumber
        {
            get
            {
                return name + " #" + number;
            }
        }
        #endregion
        #region CONSTRUCTORS
        public HockeyPlayer()
        {
            name = "";
            number = "";
        }
        public HockeyPlayer(string name, string number)
        {
            this.name = name;
            this.number = number;
        }
        #endregion
        #region INTERFACE
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
    public class HockeyTeam
    {
        #region PROPERTIES
        // Public field is not supported for xaml binding.
        // Use property instead.
        public string Name { get; set; }
        public string City { get; set; }
        #endregion
        #region CONSTRUCTORS
        public HockeyTeam()
        {
            Name = "";
            City = "None";
        }
        public HockeyTeam(string teamName, string city)
        {
            Name = teamName;
            City = city;
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return Name + "@" + City;
        }
        #endregion
    }
    public class HockeyLeague
    {
        #region VARIABLES
        List<HockeyTeam> teams = new List<HockeyTeam>();
        #endregion
        #region PROPERTIES

        #endregion
        #region CONSTRUCTORS
        public HockeyLeague()
        {
            teams.Add(new HockeyTeam("Ilves", "Tampere"));
            teams.Add(new HockeyTeam("JYP", "Jyväskylä"));
            teams.Add(new HockeyTeam("HIFK", "Helsinki"));
            teams.Add(new HockeyTeam("Kärpät", "Oulu"));
            teams.Add(new HockeyTeam("Kalpa", "Kuopio"));
        }
        #endregion
        #region METHODS
        public List<HockeyTeam> GetTeams()
        {
            return teams;
        }
        #endregion
    }
}
