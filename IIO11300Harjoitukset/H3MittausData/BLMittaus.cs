/*
 * Created: 28.1.2016 Modified 04.02.2016
 * Author: Ruben Laube-Pohto
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    [Serializable]
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
        #region METHODS
        //ylikirjoitetaan ToString
        public override string ToString()
        {
            //return base.ToString();
            return kello + "=" + mittaus;
        }
        // Tiedoston käsittely metodit
        public static void SaveToFile(string filename, List<MittausData> data)
        {
            StreamWriter sw = null;

            try
            {
                sw = File.AppendText(filename);

                foreach (MittausData md in data)
                {
                    sw.WriteLine(md);
                }
            }
            finally
            {
                try
                {
                    if (sw != null)
                    {
                        sw.Close();
                        sw.Dispose();
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        public static void SaveToFileV2(string filename, List<MittausData> data)
        {
            using (StreamWriter sw = File.AppendText(filename))
            {
                foreach (MittausData md in data)
                {
                    sw.WriteLine(md);
                }
            }
        }
        public static List<MittausData> LoadFromFile(string filename)
        {
            try
            {
                if(File.Exists(filename))
                {
                    MittausData md;
                    List<MittausData> read = new List<MittausData>();
                    string rivi = "";
                    StreamReader sr = File.OpenText(filename);

                    while ((rivi = sr.ReadLine()) != null)
                    {
                        if (rivi.Length > 3 && rivi.Contains("="))
                        {
                            string[] split = rivi.Split(new char[] { '=' });
                            md = new MittausData(split[0], split[1]);
                            read.Add(md);
                        }
                    }
                    sr.Close();
                    return read;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch
            {
                throw;
            }
        }
        public static List<MittausData> LoadFromFileV2(string filename)
        {
            List<MittausData> read = new List<MittausData>();

            using (StreamReader sr = File.OpenText(filename))
            {
                MittausData md;
                string rivi = "";

                while ((rivi = sr.ReadLine()) != null)
                {
                    if (rivi.Length > 3 && rivi.Contains("="))
                    {
                        string[] split = rivi.Split(new char[] { '=' });
                        md = new MittausData(split[0], split[1]);
                        read.Add(md);
                    }
                }
            }

            return read;
        }
        #endregion
    }
}
