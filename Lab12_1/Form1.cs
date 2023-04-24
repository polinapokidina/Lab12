using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12_1
{
    public partial class Form1 : Form
    {
        private Point pole;//центр спирали
        private Point center;//центр окружности
        private Timer timer = new Timer();//таймер
        private Pen pen = new Pen(Color.Red, 2);//Перо 
        private float phi;//угол поворота спирали (в радианах)
        public Form1()
        {
            InitializeComponent();
            pole = new Point(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2);
            timer.Tick += new EventHandler(timer_Tick);
            this.Paint += new PaintEventHandler(Form1_Paint);
            timer.Interval = 150;
            timer.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (timer.Enabled)
                    using (Graphics g = e.Graphics)
                    {
                        //Перенос начала координат в центр формы
                        g.TranslateTransform(pole.X, pole.Y);
                        //рисование окружности в заданных координатах
                        g.DrawEllipse(pen, center.X, center.Y, 25, 25);
                    }
            }

            catch { };
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            center = new Point();
            center.X = (int)((20 / (Math.PI * 2)) * phi * Math.Cos(phi));
            center.Y = (int)((20 / (Math.PI * 2)) * phi * Math.Sin(phi));
            this.Refresh();
            phi++;
        }
    }
}
