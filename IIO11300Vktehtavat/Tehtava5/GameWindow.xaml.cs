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
        private Snake snake;

        public GameWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick); // Add the method to run at every tick
            timer.Interval = new TimeSpan(0, 0, 0, 0, 17); // 17 ms, about 60 fps
            timer.Start();

            snake = new Snake(this.Width / 2, this.Height / 2); // Start at center
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            snake.Move();
            paintSnake();
        }

        private void paintSnake()
        {
            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = snake.Color;
            newEllipse.Width = snake.Size;
            newEllipse.Height = snake.Size;

            Canvas.SetTop(newEllipse, snake.Position.Y);
            Canvas.SetLeft(newEllipse, snake.Position.X);

            int count = cnvCanvas.Children.Count;
            cnvCanvas.Children.Add(newEllipse);
            snake.SaveCurrentPosition();

            // Restrict the tail of the snake
            if (count > snake.Length)
            {
                // index is i = count - snake.Length + NUMBER_OF_BONUSES - 1
                cnvCanvas.Children.RemoveAt(count - snake.Length - 1);
                snake.RemoveFromTail();
            }
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
                // Pause / Unpause
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
                case Key.Up:
                    {
                        if (snake.Direction != (int)MovementDirection.Down)
                            snake.Direction = (int)MovementDirection.Up;
                    }
                    break;
                case Key.Down:
                    {
                        if (snake.Direction != (int)MovementDirection.Up)
                            snake.Direction = (int)MovementDirection.Down;
                    }
                    break;
                case Key.Left:
                    {
                        if (snake.Direction != (int)MovementDirection.Right)
                            snake.Direction = (int)MovementDirection.Left;
                    }
                    break;
                case Key.Right:
                    {
                        if (snake.Direction != (int)MovementDirection.Left)
                            snake.Direction = (int)MovementDirection.Right;
                    }
                    break;
                default: { } break;
            }
        }
    }
}
