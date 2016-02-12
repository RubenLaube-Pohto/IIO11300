using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Tehtava5
{
    enum MovementDirection
    {
        Up,
        Right,
        Down,
        Left
    }
    class Snake
    {
        
        #region VARIABLES
        private Brush color;
        private double size;
        private Point position;
        private int length;
        private int direction;
        private double speed;
        private Queue<Point> points;
        #endregion
        #region PROPERTIES
        public Brush Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public double Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        public Point Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public int Length
        {
            get { return this.length; }
            set { this.length = value; }
        }
        public int Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }
        public double Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }
        #endregion
        #region CONSTRUCTORS
        public Snake(double x, double y)
        {
            this.position = new Point(x, y);
            // Hard coded for simplicity
            this.color = Brushes.Green;
            this.size = 10;
            this.length = 10;
            this.direction = (int)MovementDirection.Right;
            this.speed = 1.0;
            points = new Queue<Point>();
        }
        #endregion
        #region METHODS
        public void Move()
        {
            switch (direction)
            {
                case (int)MovementDirection.Down:
                    position.Y += speed;
                    break;
                case (int)MovementDirection.Up:
                    position.Y -= speed;
                    break;
                case (int)MovementDirection.Left:
                    position.X -= speed;
                    break;
                case (int)MovementDirection.Right:
                    position.X += speed;
                    break;
            }
        }
        public void SaveCurrentPosition()
        {
            points.Enqueue(position);
        }
        public void RemoveFromTail()
        {
            points.Dequeue();
        }
        #endregion
    }
}
