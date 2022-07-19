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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void buttonrezervasyon_Click(object sender, EventArgs e)
        {
            tbxtel frm = new tbxtel();
            frm.Show();
            this.Hide();
        }

        private void buttonpersonel_Click(object sender, EventArgs e)
        {
            Personel_İşlem frm = new Personel_İşlem();
            frm.Show();
            this.Hide();
        }

        private void buttonodalar_Click(object sender, EventArgs e)
        {
            Odalar frm = new Odalar();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Galerimiz h = new Galerimiz();
            h.Show();
            this.Hide();
        }

        private void buttoncıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
