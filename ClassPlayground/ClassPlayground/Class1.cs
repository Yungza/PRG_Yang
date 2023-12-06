using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Rectangle
    {
        public float width, height;
        public Rectangle(float width, float height)
        {
            this.width = width;
            this.height = height;
        }
        public Rectangle(float width)
        {
            this.width = height = width;
        }
        public float CalculateArea()
        {
            float area = width * height;
            return area;
        }
        public string CalculateAspectRatio()
        {
            string shape;
            if (width == height)
            {
                shape = "čtverec";
                return shape;
            }
            if (height > width)
            {
                shape = "vysoký";
            }
            else
            {
                shape = "široký";
            }

            return shape;
        }
        public string ContainsPoint(int x, int y)
        {
            if (x <= width)
            {
                if (y <= height)
                {
                    return $"ano, bod [{x} ; {y}] se nachází v obdélníku / čtverci";
                }
                else
                {
                    return $"ne, bod [{x} ; {y}] se nenachází v obdélníku / čtverci";
                }
            }
            else
            {
                return $"ne, bod [{x} ; {y}] se nenachází v obdélníku / čtverci";
            }
        }
    }
}
