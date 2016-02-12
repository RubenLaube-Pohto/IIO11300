using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tehtava5
{
    class Snake
    {
        private Brush color;
        private double size;
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
        #endregion

        public Snake()
        {
            this.color = Brushes.Green;
            this.size = 10;
        }
    }
}
