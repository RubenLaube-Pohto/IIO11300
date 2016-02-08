using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tehtava4
{
    public class Serialization
    {
        public static void SerialisoiXml(string tiedosto, ICollection ic)
        {
            XmlSerializer xs = new XmlSerializer(ic.GetType());
            TextWriter tw = new StreamWriter(tiedosto);
            try
            {
                xs.Serialize(tw, ic);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                tw.Close();
            }
        }
        public static List<Pelaaja> DeSerialisoiXml(string tiedosto)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Pelaaja>));
            TextReader tr = new StreamReader(tiedosto);
            try
            {
                return (List<Pelaaja>)deserializer.Deserialize(tr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tr.Close();
            }
        }
    }
}
