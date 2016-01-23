/*
 * This file is part of the IIO11300 coursework.
 *
 * Created: 22.1.2016 Modified: 23.1.2016
 * Authors: Ruben Laube-Pohto
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbDrawns.Text = "1";
            tbNumbers.Text = "";
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string type = cbGame.SelectedValue.ToString();
                int drawns = int.Parse(tbDrawns.Text);

                Lotto lotto = new Lotto(type);
                tbNumbers.Text = lotto.drawNumbers(drawns);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
