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
using System.Xml;
using System.Xml.Linq;

namespace H4TyontekijatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XElement xe;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnReadXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                const string FILENAME = "D:\\H8871\\Työntekijät2013.xml"; // Siirretään App.config:in myöhemmin
                xe = XElement.Load(FILENAME);
                dgData.DataContext = xe.Elements("tyontekija");
                tbMessage.Text = string.Format("Vakituisia työntekijöitä {0} ja joiden palkat yhteensä {1:0.00} €.",
                                                CountWorkers("vakituinen"), CalculateSalarySum("vakituinen"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int CountWorkers()
        {
            int n = 0;
            foreach (XElement el in xe.Elements("tyontekija"))
            {
                n++;
            }
            return n;
        }
        private int CountWorkers(string type)
        {
            // LINQ-kysely
            var temp = from ele
                       in xe.Elements("tyontekija")
                       where ele.Element("tyosuhde").Value == type
                       select ele.Element("sukunimi");
            return temp.Count();
        }
        private decimal CalculateSalarySum()
        {
            decimal sum = 0;
            foreach (XElement el1 in xe.Elements("tyontekija"))
            {
                foreach (XElement el2 in el1.Elements("palkka"))
                {
                    sum += Convert.ToDecimal(el2.Value);
                }
            }
            return sum;
        }
        private decimal CalculateSalarySum(string type)
        {
            decimal sum = 0;
            // LINQ-kysely
            var palkat = from ele
                         in xe.Elements()
                         where ele.Element("tyosuhde").Value == type
                         select ele.Element("palkka").Value;
            foreach (var item in palkat)
            {
                // System.Diagnostics.Debug.Print(item.ToString()); // Debugaukseen
                sum += Convert.ToDecimal(item);
            }
            return sum;
        }
    }
}
