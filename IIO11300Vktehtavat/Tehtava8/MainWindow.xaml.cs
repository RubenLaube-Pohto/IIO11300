using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;

namespace Tehtava8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGet_Clients_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(
                    Tehtava8.Properties.Settings.Default.Database))
                {
                    string sql = "SELECT firstname, lastname, address, city " +
                                 "FROM vCustomers";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable("Wines");
                    da.Fill(dt);
                    lbClients.DataContext = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbClients_SelectionChanged(object sender,
                                                SelectionChangedEventArgs e)
        {
            // There should be only one item in e.AddedItems.
            // Select the first index just to be safe.
            spDetails.DataContext = e.AddedItems[0];
        }
    }
}
