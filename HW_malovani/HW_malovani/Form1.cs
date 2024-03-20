using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_malovani
{
    public partial class Form1 : Form
    {
        public Brush brush = Brushes.Black;
        public bool mouse = false;
        Point previousLocation = new Point();
        int size = 1;
        public Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button_red_Click(object sender, EventArgs e)
        {
            brush = Brushes.Red;
        }

        private void button_blue_Click(object sender, EventArgs e)
        {
            brush = Brushes.Blue;
        }

        private void button_green_Click(object sender, EventArgs e)
        {
            brush = Brushes.Green;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Point currentPosition = e.Location;
            int x = rnd.Next(0,1110);
            int y = rnd.Next(0,642);
            Point randomPosition = new Point(x,y);
            Pen pen = new Pen(brush, size);
            if (mouse)
            {
                g.DrawLine(pen, currentPosition, previousLocation);
            }
            previousLocation = currentPosition;
            if (currentPosition.X > button_run.Location.X -20 && currentPosition.X < button_run.Location.X + 20 + button_run.Width)
            {
                if (currentPosition.Y > button_run.Location.Y -20 && currentPosition.Y < button_run.Location.Y + 20 + button_run.Height)
                {
                    button_run.Location = randomPosition;
                }
            }
        }

        private void button_black_Click(object sender, EventArgs e)
        {
            brush = Brushes.Black;
        }

        private void button_white_Click(object sender, EventArgs e)
        {
            brush = Brushes.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_size.Text, out int result))
            {
                size = Convert.ToInt32(textBox_size.Text);
            }
            else
            {
                MessageBox.Show("zadej číslo ty hajzle");
            }
        }

        private void button_up_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox_size.Text);
            x++;
            textBox_size.Text = x.ToString();
        }

        private void button_down_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox_size.Text);
            x--;
            textBox_size.Text = x.ToString();
        }

        private void button_yellow_Click(object sender, EventArgs e)
        {
            brush = Brushes.Yellow;
        }

        private void button_purple_Click(object sender, EventArgs e)
        {
            brush = Brushes.Purple;
        }

        private void button_orange_Click(object sender, EventArgs e)
        {
            brush = Brushes.Orange;
        }

        private void button_pink_Click(object sender, EventArgs e)
        {
            brush = Brushes.Pink;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
