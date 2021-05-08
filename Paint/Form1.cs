using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        
        private int mogeRysowac = 0;
        private int wielk = 1;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mogeRysowac == 1)
            {
                Graphics g = Graphics.FromHwnd(this.Handle);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Point p = new Point(e.X, e.Y);
                if (comboBox1.SelectedIndex == 1)
                {
                    g.FillRectangle(myBrush, new Rectangle(p.X - wielk, p.Y - wielk, 2 + wielk, 2 + wielk));
                }
                else
                {
                    g.FillEllipse(myBrush, new Rectangle(p.X - wielk, p.Y - wielk, 2 + wielk, 2 + wielk));
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mogeRysowac = 1;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mogeRysowac = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                myBrush.Color = colorDialog1.Color;
                button1.BackColor = colorDialog1.Color;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int test;
            if (int.TryParse(textBox1.Text, out test))
            {
                wielk = test;
            }
            else
            {
                wielk = 1;
                MessageBox.Show("Błąd. Podaj wartość liczbową.");
                textBox1.Text = "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            g.Clear(Color.White);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(ClientSize.Width, ClientSize.Height);
            bm.Save("obraz.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            bm.Dispose();
        }
    }
}
