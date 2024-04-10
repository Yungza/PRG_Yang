using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Rectangle
    {
        public int width, height, x, y;
        public Brush brush;
        public Pen pen;
        public bool isFilled;
        public Rectangle(int width, int height, int x, int y, Brush brush, Pen pen, bool isFilled)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.brush = brush;
            this.pen = pen;
            this.isFilled = isFilled;
        }
        public void Draw(Graphics g)
        {

            if (isFilled)
            {
                g.FillRectangle(brush, x, y, width, height);
            }
            else
            {
                g.DrawRectangle(pen, x, y, width, height);
            }
        }
        public void Reposition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Resize(int x, int y)
        {
            width = Math.Abs(x - this.x);
            height = Math.Abs(y - this.y);
        }
    }
}
