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

namespace Tehtava4
{
    class Pelaaja
    {
        #region VARIABLES
        private string firstName;
        private string lastName;
        private string team;
        private double transferCost;
        #endregion
        #region PROPERTIES
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Team
        {
            get { return team; }
            set { team = value; }
        }
        public double TransferCost
        {
            get { return transferCost; }
            set { transferCost = value; }
        }
        public string FullName { get { return lastName + " " + firstName; } }
        public string DisplayName { get { return firstName + " " + lastName + ", " + team; } }
        #endregion
        #region CONSTRUCTORS
        public Pelaaja(string firstName, string lastName, string team, double transferCost)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.team = team;
            this.transferCost = transferCost;
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return DisplayName;
        }
        #endregion
    }
}
