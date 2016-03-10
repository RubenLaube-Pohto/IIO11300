using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H7ADONETConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Create connection
                string connStr = H7ADONETConsole.Properties.Settings.Default.Database;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // 2. Create command and execute it
                    string sql = "SELECT asioid, lastname, firstname, date FROM presences WHERE asioid='H8871'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();

                    // 3. Loop through results
                    if (sdr.HasRows)
                    {
                        int count = 0;
                        while (sdr.Read())
                        {
                            string id = sdr.GetString(0);
                            string lastname = sdr.GetString(1);
                            string firstname = sdr.GetString(2);
                            string date = sdr.GetDateTime(3).ToShortDateString();
                            Console.WriteLine("Läsnäolosi {0} {1} {2} {3}", id, firstname, lastname, date);
                            count++;
                        }
                        Console.WriteLine("Tulostettu {0} läsnäoloa.", count);
                    }

                    // 4. Close the connection (With 'using' should close automatically.
                    // Without 'using' would be better to close in 'finally'-block)
                    sdr.Close();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to close...");
                Console.ReadKey();
            }
        }
    }
}
