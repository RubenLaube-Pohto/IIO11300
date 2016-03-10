using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H8ADONETWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(H8ADONETWPF.Properties.Settings.Default.Database))
                {
                    // Use data adapter to link datasource to element
                    string sql = "SELECT asioid, lastname, firstname, date FROM presences WHERE asioid='H8871'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable("Presences");
                    da.Fill(dt);

                    // Bind to UI control
                    dgMyGrid.DataContext = dt;

                    // Close (to be safe)
                    conn.Close();
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
