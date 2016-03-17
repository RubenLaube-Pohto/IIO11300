//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
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
using JAMK.ICT;
using JAMK.ICT.Data;
using System.Data;

namespace JAMK.ICT.ADOBlanco
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private string ConnStr;
    private string TableName;
    private DataTable dt;
    private DataView dv;

    public MainWindow()
    {
      InitializeComponent();
      IniMyStuff();
    }

    private void IniMyStuff()
    {
        string message = "";
        try
        {
            //TODO täytetään combobox asiakkaitten maitten nimillä
            //esimerkki kuinka App.Configissa oleva connectionstring luetaan
            ConnStr = Properties.Settings.Default.Tietokanta;
            TableName = Properties.Settings.Default.Taulu;
            //lbMessages.Content = JAMK.ICT.Properties.Settings.Default.Tietokanta;
            lbMessages.Content = ConnStr;

            dt = DBPlacebo.GetAllCustomersFromSQLServer(ConnStr, TableName, "", out message);
            dv = dt.DefaultView;

            FillMyComboV2();
        }
        catch (Exception ex)
        {
            lbMessages.Content = ex.Message;
        }
    }

    private void FillMyComboV1()
    {
        // kaupungit
        cbCountries.ItemsSource = DBPlacebo.GetCitiesFromSQLServer(ConnStr, TableName).DefaultView;
        cbCountries.DisplayMemberPath = "city";
        cbCountries.SelectedValuePath = "city";
    }

    private void FillMyComboV2()
    {
        // LINQ - huom "normi" datatable käytä AsEnumerable()
        var result = (from c in dt.AsEnumerable()
                        select c.Field<string>("City")).Distinct().ToList();
        cbCountries.ItemsSource = result;
    }

        private void btnGet3_Click(object sender, RoutedEventArgs e)
    {
      dgCustomers.ItemsSource = DBPlacebo.GetTestCustomers().DefaultView;
    }

    private void btnGetAll_Click(object sender, RoutedEventArgs e)
    {
        string message = "";
        try
        {
            //dgCustomers.ItemsSource = DBPlacebo.GetAllCustomersFromSQLServer(ConnStr, TableName, "", out message).DefaultView;
            //dt.DefaultView.RowFilter = "";
            //dgCustomers.ItemsSource = dt.DefaultView;
            dv.RowFilter = "";
            dgCustomers.ItemsSource = dv;
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        finally
        {
            lbMessages.Content = message;
        }
    }

    private void btnGetFrom_Click(object sender, RoutedEventArgs e)
    {
      //TODO
    }

        private void btnYield_Click(object sender, RoutedEventArgs e)
        {
            JAMK.ICT.JSON.JSONPlacebo2015 roskaa = new JAMK.ICT.JSON.JSONPlacebo2015();
            MessageBox.Show(roskaa.Yield());
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // V1 hakee aina uudestaan palvelimelta
            //string message = "";
            //string kaupunki = "";
            //try
            //{
            //    if (cbCountries.SelectedIndex>=0)
            //    {
            //        kaupunki = cbCountries.SelectedValue.ToString();
            //        string filter = string.Format("city = '{0}'", kaupunki);
            //        dt.DefaultView.RowFilter = filter;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    message = ex.Message;
            //}
            //finally
            //{
            //    lbMessages.Content = message;
            //}
            // V2
            dv.RowFilter = string.Format(
                "city = '{0}'", cbCountries.SelectedValue.ToString()
            );
        }
    }
}
