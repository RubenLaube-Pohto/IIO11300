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
        public GameWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick); // Liitetään toiminto, joka tehdään
            timer.Interval = new TimeSpan(0, 0, 0, 0, 17); // 17 ms, noin 60 fps
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                // Exit to main menu
                case Key.Escape:
                    {
                        MainWindow main = new MainWindow();
                        Application.Current.MainWindow = main;
                        this.Close();
                        main.Show();
                    }
                    break;
            }
        }
    }
}
