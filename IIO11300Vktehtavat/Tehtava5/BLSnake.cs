using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Tehtava5
{
    class Snake
    {
        #region VARIABLES
        private Brush color;
        private double size;
        private Point position;
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
        #endregion

        public Snake(double x, double y)
        {
            this.position = new Point(x, y);
            this.color = Brushes.Green;
            this.size = 10;
        }
    }
}
