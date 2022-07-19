using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel
{
    public partial class Galerimiz : Form
    {
        public Galerimiz()
        {
            InitializeComponent();
        }
        int i = 0,k=1,j=2,a=3,b=4,c=5,d=6;

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            this.Hide();
            menu.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            i++;
            j++;
            k++;
            a++;
            b++;
            c++;
            d++;
            if (i == 16  )
            {
                i = 0;
                
            }
            if ( k == 16)
            {
                k = 0;
               
            }
            if ( j == 16 )
            {
               
                j = 0;
               
            }
            if (a == 16 )
            {
               
                a = 0;
               
            }
            if (b == 16)
            {
                
                b = 0;
                
            }
            if ( c == 16)
            {
               
                c = 0;
              
            }
            if (d == 16)
            {
               
                d = 0;
            }

            pictureBox1.Image = ımageList1.Images[i];
            pictureBox2.Image = ımageList1.Images[j];
            pictureBox3.Image = ımageList1.Images[k];
            pictureBox4.Image = ımageList1.Images[a];
            pictureBox5.Image = ımageList1.Images[b];
            pictureBox6.Image = ımageList1.Images[c];
            pictureBox7.Image = ımageList1.Images[d];


        }

        private void Galerimiz_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 2000;
            pictureBox1.Image = ımageList1.Images[0];
        }

       
    }
}
