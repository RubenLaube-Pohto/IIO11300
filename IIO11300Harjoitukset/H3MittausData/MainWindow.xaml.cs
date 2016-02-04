/*
 * Created: 28.1.2016 Modified: 04.02.2016
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
using JAMK.IT.IIO11300;

namespace H3MittausData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Luodaan lista mittaus-olioita varten.
        List<MittausData> measureds;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            //omat ikkunaan liittyvät alustukset
            txtToday.Text = DateTime.Today.ToShortDateString();
            measureds = new List<MittausData>();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            //luodaan uusi mittausdata olio ja näytetään se käyttäjälle
            MittausData md = new MittausData(txtClock.Text, txtData.Text);
            // lbData.Items.Add(md); // testausta varten
            measureds.Add(md);
            ApplyChanges();
        }

        private void ApplyChanges()
        {
            lbData.ItemsSource = null;
            lbData.ItemsSource = measureds;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MittausData.SaveToFileV2(txtFileName.Text, measureds);
                MessageBox.Show("Tiedot tallennettu onnistuneesti tiedostoon " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                measureds = MittausData.LoadFromFileV2(txtFileName.Text);
                ApplyChanges();
                MessageBox.Show("Tiedot luettu onnistuneesti tiedostosta " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSerialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JAMK.IT.IIO11300.Serialisointi.SerialisoiXml(txtFileName.Text, measureds);
                MessageBox.Show("Tiedot onnistuneesti serialisoitu tiedostoon " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                measureds = JAMK.IT.IIO11300.Serialisointi.DeSerialisoiXml(txtFileName.Text);
                ApplyChanges();
                MessageBox.Show("Tiedot onnistuneesti deserialisoitu tiedostosta " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSerializeBin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JAMK.IT.IIO11300.Serialisointi.Serialisoi(txtFileName.Text, measureds);
                MessageBox.Show("Tiedot onnistuneesti serialisoitu tiedostoon " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeserializeBin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object obj = new object();
                JAMK.IT.IIO11300.Serialisointi.DeSerialisoi(txtFileName.Text, ref obj);
                measureds = (List<MittausData>)obj;
                ApplyChanges();
                MessageBox.Show("Tiedot onnistuneesti deserialisoitu tiedostosta " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
