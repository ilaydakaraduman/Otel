using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otel
{
    public partial class Sifre : Form
    {
        public Sifre()
        {
            InitializeComponent();
        }
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=OTEL_PROJE;integrated security=true");
        private void tbxgir_Click_1(object sender, EventArgs e)
        {
            _connection.Open();
 SqlCommand command = new SqlCommand("Select Isim_Soyad, Sifre from Personel where Isim_Soyad = '" + tbxKullanıcı.Text + "' and Sifre ='" + tbxSifre.Text + "'", _connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                menu Menu = new menu();
                Menu.Show();
                this.Hide();
                _connection.Close();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre girişi");
                _connection.Close();
            }

        }
        private void tbxSifre_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                tbxSifre.UseSystemPasswordChar = false;
            else
                tbxSifre.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                tbxSifre.UseSystemPasswordChar = false;
           
        }

        private void Sifre_Load(object sender, EventArgs e)
        {

        }

       
    }
}
