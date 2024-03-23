using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public int dodgeCount = 0;
        public string action = "pen";
        Point point1 = new Point(-1);
        Point point2 = new Point(-1);
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
            Pen pen = new Pen(brush,size);
            Graphics g = this.CreateGraphics();
            switch (action)
            {
                case "fill":
                    g.FillRectangle(brush, 0, 0, 10000, 10000); // kinda weird but it's bcs I dunno how to convert system.brush.colour to drawing colour     
                    break;
                case "rectangle": // rectangle defined by 2 points
                    if (point1.X == -1) // determines if it is first point or second one
                    {
                        point1 = e.Location;
                    }
                    else if (point2.X == -1)
                    {
                        point2 = e.Location;
                        if (point1.Y < point2.Y && point1.X < point2.X) // working with coords to draw the right rectangle
                        {
                            g.DrawRectangle(pen, point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
                        }
                        else if (point2.Y < point1.Y && point2.X < point1.X)
                        {
                            g.DrawRectangle(pen, point2.X, point2.Y, point1.X - point2.X, point1.Y - point2.Y);
                        }
                        else if (point1.Y > point2.Y && point1.X < point2.X)
                        {
                            g.DrawRectangle(pen, point1.X, point2.Y, point2.X - point1.X, point1.Y - point2.Y);
                        }
                        else
                        {
                            g.DrawRectangle(pen, point2.X, point1.Y, point1.X - point2.X, point2.Y - point1.Y);
                        }
                        point1.X = -1;
                        point2.X = -1;
                    }
                    break;
                case "ellipse": // ellipse defined by rectangle defined by 2 points
                    if (point1.X == -1)
                    {
                        point1 = e.Location;
                    }
                    else if (point2.X == -1)
                    {
                        point2 = e.Location;
                        if (point1.Y < point2.Y && point1.X < point2.X)
                        {
                            g.DrawEllipse(pen, point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
                        }
                        else if (point2.Y < point1.Y && point2.X < point1.X)
                        {
                            g.DrawEllipse(pen, point2.X, point2.Y, point1.X - point2.X, point1.Y - point2.Y);
                        }
                        else if (point1.Y > point2.Y && point1.X < point2.X)
                        {
                            g.DrawEllipse(pen, point1.X, point2.Y, point2.X - point1.X, point1.Y - point2.Y);
                        }
                        else
                        {
                            g.DrawEllipse(pen, point2.X, point1.Y, point1.X - point2.X, point2.Y - point1.Y);
                        }
                        point1.X = -1;
                        point2.X = -1;
                    }
                    break;
                case "fillRectangle":
                    if (point1.X == -1)
                    {
                        point1 = e.Location;
                    }
                    else if (point2.X == -1)
                    {
                        point2 = e.Location;
                        if (point1.Y < point2.Y && point1.X < point2.X)
                        {
                            g.FillRectangle(brush, point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
                        }
                        else if (point2.Y < point1.Y && point2.X < point1.X)
                        {
                            g.FillRectangle(brush, point2.X, point2.Y, point1.X - point2.X, point1.Y - point2.Y);
                        }
                        else if (point1.Y > point2.Y && point1.X < point2.X)
                        {
                            g.FillRectangle(brush, point1.X, point2.Y, point2.X - point1.X, point1.Y - point2.Y);
                        }
                        else
                        {
                            g.FillRectangle(brush, point2.X, point1.Y, point1.X - point2.X, point2.Y - point1.Y);
                        }
                        point1.X = -1;
                        point2.X = -1;
                    }
                    break;
                case "fillEllipse":
                    if (point1.X == -1)
                    {
                        point1 = e.Location;
                    }
                    else if (point2.X == -1)
                    {
                        point2 = e.Location;
                        if (point1.Y < point2.Y && point1.X < point2.X)
                        {
                            g.FillEllipse(brush, point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
                        }
                        else if (point2.Y < point1.Y && point2.X < point1.X)
                        {
                            g.FillEllipse(brush, point2.X, point2.Y, point1.X - point2.X, point1.Y - point2.Y);
                        }
                        else if (point1.Y > point2.Y && point1.X < point2.X)
                        {
                            g.FillEllipse(brush, point1.X, point2.Y, point2.X - point1.X, point1.Y - point2.Y);
                        }
                        else
                        {
                            g.FillEllipse(brush, point2.X, point1.Y, point1.X - point2.X, point2.Y - point1.Y);
                        }
                        point1.X = -1;
                        point2.X = -1;
                    }
                    break;
                case "line":
                    if (point1.X == -1)
                    {
                        point1 = e.Location;
                    }
                    else if (point2.X == -1)
                    {
                        point2 = e.Location;
                        g.DrawLine(pen, point1,point2);
                        point1.X = -1;
                        point2.X = -1;
                    }
                    break;
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Point currentPosition = e.Location;
            int x = rnd.Next(0,1110);
            int y = rnd.Next(0,642);
            Point randomPosition = new Point(x,y);
            Pen pen = new Pen(brush, size);
            Pen eraser = new Pen(Brushes.White, size);
            switch (action)
            {
                case "pen": // normal line, looks kinda weird but less blank space when going fast than drawing ellipses or rectangles ig
                    if (mouse)
                    {
                        g.DrawLine(pen, currentPosition, previousLocation);
                    }
                    previousLocation = currentPosition;
                    break;
                case "eraser": // eraser, yes it is just white brush
                    if (mouse)
                    {
                        g.DrawLine(eraser, currentPosition, previousLocation);
                    }
                    previousLocation = currentPosition;
                    break;
                case "crayon": // works best with size around 20 :), basically fillinh ellipses around cursor position with random transparency
                    if(mouse)
                    {
                        for (int i = currentPosition.X - size / 2; i < currentPosition.X + size / 2; i=i+size/5)
                        {
                            for (int j = currentPosition.Y - size / 2; j < currentPosition.Y + size / 2; j=j+size/5)
                            {
                                SolidBrush crayon = new SolidBrush(Color.FromArgb(rnd.Next(0,255), 0, 0, 0));
                                g.FillEllipse(crayon, i, j, size/4, size/4);
                            }
                        }
                    }
                    break;
                case "calligraphic": // the faster you go, the thiner is the size, speed is determined by distance between 2 points in limited time
                    if (mouse)
                    {
                        float aSquare = (currentPosition.X - previousLocation.X) * (currentPosition.X - previousLocation.X);
                        float bSquare = (currentPosition.Y - previousLocation.Y) * (currentPosition.Y - previousLocation.Y);
                        float length = (float)Math.Sqrt(aSquare + bSquare);
                        pen.Width = (pen.Width / length); // actually thought I would never need equation for distance between 2 points irl lol
                        g.DrawLine(pen, currentPosition, previousLocation);
                    }
                    previousLocation = currentPosition;
                    break;
                case "text": // drawing with specific string
                    if (mouse)
                    {
                        Font font = new Font("a", size, FontStyle.Regular);
                        g.DrawString(textBox_write.Text, font, brush, currentPosition);
                    }
                    break;
            }
           
            if (currentPosition.X > button_run.Location.X -20 && currentPosition.X < button_run.Location.X + 20 + button_run.Width) // what is this??
            {
                if (currentPosition.Y > button_run.Location.Y -20 && currentPosition.Y < button_run.Location.Y + 20 + button_run.Height)
                {
                    button_run.Location = randomPosition;
                    dodgeCount++;
                    if (dodgeCount == 5)
                    {
                        this.BackgroundImage = Properties.Resources.bio_soja_edamame_chiba_green_glycine_max_prodej_bio_semen_20_ks;
                        Process.Start("https://www.youtube.com/watch?v=K6BRna4_bmg"); // totally not rikroll
                    }
                }
            }
        }

        private void button_black_Click(object sender, EventArgs e)
        {
            brush = Brushes.Black;
        }

        private void button_white_Click(object sender, EventArgs e)
        {
            action = "text";
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // size of pens
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

        private void button_pen_Click(object sender, EventArgs e)
        {
            action = "pen";
        }

        private void button_bucket_Click(object sender, EventArgs e)
        {
            action = "fill";
        }

        private void button_eraser_Click(object sender, EventArgs e)
        {
            action = "eraser";
        }

        private void button_square_Click(object sender, EventArgs e)
        {
            action = "rectangle";
        }

        private void button_ellipse_Click(object sender, EventArgs e)
        {
            action = "ellipse";
        }

        private void button_fillSquare_Click(object sender, EventArgs e)
        {
            action = "fillRectangle";
        }

        private void button_fillEllipse_Click(object sender, EventArgs e)
        {
            action = "fillEllipse";
        }

        private void button_clear_Click(object sender, EventArgs e) // initialize a new form
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void button_transparent_Click(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Turquoise;
            brush = Brushes.Turquoise;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            action = "crayon";
            textBox_size.Text = "20"; // as I sayd, works best around 20 :)
        }

        private void button_line_Click(object sender, EventArgs e)
        {
            action = "line";
        }

        private void button_calligraphic_Click(object sender, EventArgs e)
        {
            action = "calligraphic";
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
