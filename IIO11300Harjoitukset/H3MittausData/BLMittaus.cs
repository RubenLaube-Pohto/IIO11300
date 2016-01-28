/*
 * Created: 28.1.2016
 * Author: Ruben Laube-Pohto
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public class MittausData
    {
        #region VARIABLES
        private string kello;
        private string mittaus;
        #endregion
        #region PROPERTIES
        public string Kello
        {
            get { return kello; }
            set { kello = value; }
        }
        public string Mittaus
        {
            get { return mittaus; }
            set { mittaus = value; }
        }
        #endregion
        #region CONSTRUCTORS
        //luokalle tehdään kaksi konstruktoria
        public MittausData()
        {
            kello = "0:00";
            mittaus = "empty";
        }
        public MittausData(string klo, string mdata)
        {
            this.kello = klo;
            this.mittaus = mdata;
        }
        #endregion
        //ylikirjoitetaan ToString
        public override string ToString()
        {
            //return base.ToString();
            return kello + "=" + mittaus;
        }
    }
}
