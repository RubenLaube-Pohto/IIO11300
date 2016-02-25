using System.Collections.Generic;

namespace H6DataBinding
{
    public class HockeyPlayer
    {

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
