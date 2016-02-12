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
using System.Windows.Shapes;
using System.Windows.Threading; // DispatcherTimer

namespace Tehtava5
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private DispatcherTimer timer;
        public GameWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick); // Liitetään toiminto, joka tehdään
            timer.Interval = new TimeSpan(0, 0, 0, 0, 17); // 17 ms, noin 60 fps
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("tick");
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                // Exit to main menu
                case Key.Escape:
                    {
                        timer.Stop();
                        timer = null;
                        MainWindow main = new MainWindow();
                        Application.Current.MainWindow = main;
                        this.Close();
                        main.Show();
                    }
                    break;
                case Key.P:
                    {
                        if (timer.IsEnabled)
                        {
                            timer.Stop();
                            this.Title = "Paused";
                        }
                        else
                        {
                            timer.Start();
                            this.Title = "GameWindow";
                        }
                    }
                    break;
            }
        }
    }
}
