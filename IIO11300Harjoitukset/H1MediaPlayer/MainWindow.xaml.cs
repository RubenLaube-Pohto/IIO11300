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
using Microsoft.Win32;

namespace JAMK.IT.MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsPlaying = false;

        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        private void InitMyStuff()
        {
            // Kootaan tänne kaikki tarvittavat alustukset.
            txtFileName.Text = "D:\\H8871\\Media\\CoffeeMaker.mp4";
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtFileName.Text.Length > 0 && System.IO.File.Exists(txtFileName.Text))
                {
                    mediaElement.Source = new Uri(txtFileName.Text);
                    mediaElement.Play();
                    IsPlaying = true;
                    SetButtons();
                }
                else
                {
                    throw new System.IO.FileNotFoundException();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (IsPlaying)
            {
                mediaElement.Pause();
                IsPlaying = false;
                btnPause.Content = "Resume";
            }
            else
            {
                mediaElement.Play();
                IsPlaying = true;
                btnPause.Content = "Pause";
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            IsPlaying = false;
            mediaElement.Source = null;
            SetButtons();
        }

        private void SetButtons()
        {
            btnPlay.IsEnabled = !IsPlaying;
            btnStop.IsEnabled = IsPlaying;
            btnPause.IsEnabled = IsPlaying;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Haetaan käyttäjän vakiodialogilla valitsema tiedosto
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\H8871\\Media";
            ofd.Filter = "Video-tiedostot .mp4|*.mp4|Musiikki-tiedostot .mp3|*.mp3|All files|*.*";
            Nullable<bool> result = ofd.ShowDialog();
            if(result== true)
            {
                txtFileName.Text = ofd.FileName;
            }
        }
    }
}