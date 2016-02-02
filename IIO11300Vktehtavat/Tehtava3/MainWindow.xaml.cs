/*
 * Weekly Task 3
 * Created: 29.1.2016 Modified: 02.02.2016
 * Author: Ruben Laube-Pohto
 */
using System;
using System.Collections.Generic;
using System.IO;
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

namespace JAMK.IT.IIO11300
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

        private void btnGet_files_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dir = tbSource_dir.Text;

                Combiner combiner = new Combiner();
                FileInfo[] fiArray = combiner.getTxtFiles(dir);

                string foundFiles = "";
                foreach (FileInfo fi in fiArray) {
                    foundFiles += fi.FullName;
                    foundFiles += '\n';
                }

                tbFound_files.Text = foundFiles;
                tbStatus.Text = "Found " + fiArray.Length.ToString() + " files.";
            }
            catch (Exception ex)
            {
                tbStatus.Text = ex.Message;
            }
        }
    }
}
