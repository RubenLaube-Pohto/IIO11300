/*
 * Harjoitus IIO11300 kurssille
 * Created: 14.1.2016 Modified: 28.1.2016
 * Author: Ruben Laube-Pohto
 */
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

namespace JAMK.IT.MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }
        private void InitMyStuff()
        {
            // TODO: Kootaan tänne kaikki tarvittavat alustukset.
            txtFileName.Text = "D:\\H8871\\Media\\CoffeeMaker.mp4";
        }
    }
}