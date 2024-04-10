using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Rectangle rectangle;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rectangle = new Rectangle(100, 100, 100, 100, Brushes.Black, Pens.Green, false);
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            rectangle.Draw(e.Graphics);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'f')
            {
                rectangle.isFilled = !rectangle.isFilled;
                Refresh();  
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                rectangle.Reposition(e.X, e.Y);
                Refresh();
            }
            else if(e.Button == MouseButtons.Right)
            {
                rectangle.Resize(e.X, e.Y);
                Refresh();
            }

        }
    }
}
