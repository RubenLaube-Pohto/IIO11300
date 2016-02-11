using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace H4TyontekijatConsole
{
    class Program
    {
        static void ReadWorkersFromXML(string fileName)
        {
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(fileName);
                    // Haetaan XPath:lla
                    XmlNodeList xnl = xmldoc.SelectNodes("/tyontekijat/tyontekija");
                    XmlNode xn;
                    XmlNodeList xnl2;
                    for (int i = 0; i < xnl.Count; i++)
                    {
                        xn = xnl.Item(i);
                        Console.WriteLine(xn.InnerText);
                        xnl2 = xn.ChildNodes;
                        for (int j = 0; j < xnl2.Count; j++)
                        {
                            Console.WriteLine(xnl2.Item(j).InnerText);
                        }
                    }
                }
            }
            catch { throw; }
        }
        static void CalculateSalarySumFromXML(string fileName)
        {
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(fileName);
                    // Haetaan XPath:lla
                    XmlNodeList xnl = xmldoc.SelectNodes("/tyontekijat/tyontekija[tyosuhde='vakituinen']/palkka");
                    int sum = 0;
                    for (int i = 0; i < xnl.Count; i++)
                    {
                        sum += Convert.ToInt32(xnl[i].InnerText);
                    }
                    Console.WriteLine(string.Format("Vakituisia on {0} ja heidän palkat yhteensä {1}.", xnl.Count, sum));
                }
            }
            catch { throw; }
        }
        static void Main(string[] args)
        {
            string fileName = "d:\\H8871\\Työntekijät2013.xml";

            try
            {
                // ReadWorkersFromXML(fileName);
                CalculateSalarySumFromXML(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}