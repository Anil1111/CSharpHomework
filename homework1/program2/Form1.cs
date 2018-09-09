using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework1_win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GetProduct_Click(object sender, EventArgs e)
        {
            if(this.number1.Text=="")
            {
                this.number1.Text = "请输入数字";
                return;
            }else if(this.number2.Text=="")
            {
                this.number2.Text = "请输入数字";
                return;
            }
            double x = Convert.ToDouble(this.number1.Text);
            double y = Convert.ToDouble(this.number2.Text);
            this.number1.Text = "";
            this.number2.Text = "";
            this.product.Text = "两数乘积为" + (x * y);
        }
        
    }
}
