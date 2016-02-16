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
        const int NUM_OF_BONUSES = 20;
        private DispatcherTimer timer;
        private Snake snake;
        private List<Point> bonusPoints;
        private Random rnd;
        private int score;

        public GameWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick); // Add the method to run at every tick
            timer.Interval = new TimeSpan(0, 0, 0, 0, 17); // 17 ms, about 60 fps
            timer.Start();

            score = 0;
            this.Title = "Bonus points: " + score.ToString();
            rnd = new Random();
            snake = new Snake(cnvCanvas.Width / 2, cnvCanvas.Height / 2); // Start at center
            bonusPoints = new List<Point>();
            for (int n = 0; n < NUM_OF_BONUSES; n++)
            {
                paintBonus(n);
            }

            System.Diagnostics.Debug.Print(cnvCanvas.Width.ToString());
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            snake.Move();
            paintSnake();

            // Restrict to boundaries of the Canvas
            if ((snake.Position.X < 0) || (snake.Position.X > cnvCanvas.Width - snake.Size * 2) ||
                (snake.Position.Y < 0) || (snake.Position.Y > cnvCanvas.Height - snake.Size * 2))
                GameOver();

            // Hitting a bonus Point causes the lengthen-Snake Effect
            int n = 0;
            foreach (Point point in bonusPoints)
            {

                if ((Math.Abs(point.X - snake.Position.X) < snake.Size) &&
                    (Math.Abs(point.Y - snake.Position.Y) < snake.Size))
                {
                    snake.Length += 10;
                    snake.Speed += 0.5;
                    score++;
                    this.Title = "Bonus points: " + score.ToString();

                    // In the case of food consumption, erase the food object
                    // from the list of bonuses as well as from the canvas
                    bonusPoints.RemoveAt(n);
                    cnvCanvas.Children.RemoveAt(n);
                    paintBonus(n);
                    break;
                }
                n++;
            }

            // Restrict hits to body of Snake
            for (int q = 0; q < (snake.Points.Count - snake.Size * 2); q++)
            {
                Point point = new Point(snake.Points.ElementAt(q).X, snake.Points.ElementAt(q).Y);
                if ((Math.Abs(point.X - snake.Position.X) < (snake.Size)) &&
                     (Math.Abs(point.Y - snake.Position.Y) < (snake.Size)))
                {
                    GameOver();
                    break;
                }
            }
        }

        private void GameOver()
        {
            timer.Stop();
            timer = null;
            MainWindow main = new MainWindow();
            Application.Current.MainWindow = main;
            this.Close();
            main.Show();
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

            // Restrict the tail of the snake by checking how many objects are being drawn
            if (count > (snake.Length + NUM_OF_BONUSES))
            {
                // Bonuses are drawn first and then the snake from tail to head
                cnvCanvas.Children.RemoveAt(NUM_OF_BONUSES);
                snake.RemoveFromTail();
            }
        }

        private void paintBonus(int index)
        {
            Point bonusPoint = new Point(rnd.Next(5, 620), rnd.Next(5, 380));

            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = Brushes.Red;
            newEllipse.Width = snake.Size;
            newEllipse.Height = snake.Size;

            Canvas.SetTop(newEllipse, bonusPoint.Y);
            Canvas.SetLeft(newEllipse, bonusPoint.X);
            cnvCanvas.Children.Insert(index, newEllipse);
            bonusPoints.Insert(index, bonusPoint);
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
                            this.Title = "Bonus points: " + score.ToString();
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
