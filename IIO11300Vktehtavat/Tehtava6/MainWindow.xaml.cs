﻿using System;
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
using System.Configuration;

namespace Tehtava6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public MainWindow()
        {
            InitializeComponent();
            txtFilePath.Text = ConfigurationManager.AppSettings["File"];
        }

        private void btnFetch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the element from xaml
                XmlDataProvider xdpWineData = (XmlDataProvider)this.FindResource("WineData");
                // Set source from app.config. Accepts absolute or relative uri.
                xdpWineData.Source = new Uri(txtFilePath.Text, UriKind.RelativeOrAbsolute);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
