using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        double ratio = 0.6;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartDrawing(object sender, EventArgs e)
        {
            if(graphics==null)
            {
                graphics = this.CreateGraphics();
            }
            DrawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private void DrawCayleyTree(int n,double x0, double y0, double leng, double th)
        {
            if (n == 0)
                return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = (x1 - x0) * ratio + x0;
            double y2 = (y1 - y0) * ratio + y0;
            DrawLine(x0, y0, x1, y1);

            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }

        private void DrawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

      

        private void ratioText_TextChanged(object sender, EventArgs e)
        {
            ratio = Convert.ToDouble(ratioText.Text);
        }

        private void th1Text_TextChanged(object sender, EventArgs e)
        {
            th1 = Convert.ToDouble(th1Text.Text);
        }

        private void th2Text_TextChanged(object sender, EventArgs e)
        {
            th2 = Convert.ToDouble(th2Text.Text);
        }

        private void per1Text_TextChanged(object sender, EventArgs e)
        {
            per1 = Convert.ToDouble(per1Text.Text);
        }

        private void per2Text_TextChanged(object sender, EventArgs e)
        {
            per2 = Convert.ToDouble(per2Text.Text);
        }
    }
}
