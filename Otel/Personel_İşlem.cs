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
    public partial class Personel_İşlem : Form
    {
        public Personel_İşlem()
        {
            InitializeComponent();
        }
        PersonelBilgi prsonel = new PersonelBilgi();

        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=OTEL_PROJE;integrated security=true");
      
       
            public class temizlik :Personel_İşlem
             {
            public string kontrol;
            public bool durum;
            public void islem()
            {
                if (durum == true)
                {
                    kontrol = "Temizlik Yapıldı.";
                }
                else
                {
                    kontrol = "Temizlik Yapılmadı";
                }

            }

        }

        public class rezervasyon 
        {
            public string kontrol;
            public bool durum;
            public void islem()
            {
                if (durum == true)
                {
                    kontrol = "Rezervasyon Yapıldı.";
                }
                else
                {
                    kontrol = "Rezervasyon Yapılmadı";
                }

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (tbxisim.Text != "" || pickertarih.Text != "")
            {
                temizlik tem = new temizlik();
                tem.durum = checktemizlik.Checked;
                tem.islem();
                labelkontrol.Text = tem.kontrol;

                if (listoda.Items.Count > 0)
                {
                    for (int i = 0; i < listoda.Items.Count; i++)
                    {
                        prsonel.AddTemizlik(new Personel
                        {
                            Isim_Soyad = tbxisim.Text,
                            Tarih = Convert.ToDateTime((pickertarih.Text)),
                            IslemBilgisi = labelkontrol.Text,
                            OdaNo = Convert.ToInt16(listoda.Items[i]),
                            RezervasyonID = 0

                        }) ;
                    }
                }

                else
                {
                    prsonel.AddTemizlik(new Personel
                    {
                        Isim_Soyad = tbxisim.Text,
                        Tarih = Convert.ToDateTime((pickertarih.Text)),
                        IslemBilgisi = labelkontrol.Text,
                        OdaNo = 0,
                        RezervasyonID=0
                    });
                }
                dataGridView1.DataSource = prsonel.GetAllTemizlik();
            }      
            else
                MessageBox.Show("Tarih ve isim boş bırakılamaz");

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxisim2.Text != "" || pickertarih2.Text != "")
            {
                rezervasyon rez = new rezervasyon();
                rez.durum = checkrezervasyon.Checked;
                rez.islem();
                kontrolrezervasyon.Text = rez.kontrol;

                if (listID.Items.Count > 0)
                {
                    for (int i = 0; i < listID.Items.Count; i++)
                    {
                        prsonel.AddRezerve(new Personel
                        {
                            Isim_Soyad = tbxisim2.Text,
                            Tarih = Convert.ToDateTime((pickertarih2.Text)),
                            IslemBilgisi = kontrolrezervasyon.Text,
                            RezervasyonID = Convert.ToInt16(listID.Items[i]),
                            OdaNo=0,
                        });
                    }
                }
                else
                {
                    prsonel.AddRezerve(new Personel
                    {
                        Isim_Soyad = tbxisim2.Text,
                        Tarih = Convert.ToDateTime((pickertarih2.Text)),
                        IslemBilgisi = kontrolrezervasyon.Text,
                        RezervasyonID = 0,
                        OdaNo = 0
                    }) ;
                }
                dataGridView2.DataSource = prsonel.GetAllRezerve();
            }
            else
                MessageBox.Show("Tarih ve isim boş bırakılamaz.");
        }

        private void buttonoda_Click(object sender, EventArgs e)
        {
            
            listoda.Items.Add(tbxoda.Text);
            tbxoda.Clear();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }
       
        private void Personel_İşlem_Load(object sender, EventArgs e)
        {           
            dataGridView1.DataSource = prsonel.GetAllTemizlik();
            dataGridView2.DataSource = prsonel.GetAllRezerve();
           
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void menubutton_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }
        private void tbxisim_Click(object sender, EventArgs e)
        {
            tbxisim.Items.Clear();
            _connection.Open();
            SqlCommand command = new SqlCommand("Select * from Personel where Departman ='Oda Sorumlusu' or Departman ='Odalar Müdürü'", _connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {                
                tbxisim.Items.Add(reader[1]);
            }
            _connection.Close();       
        }
              private void tbxisim2_Click(object sender, EventArgs e)
        {
            tbxisim2.Items.Clear();
            _connection.Open();
            SqlCommand command = new SqlCommand("Select * from Personel where Departman ='Rezervasyon'", _connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tbxisim2.Items.Add(reader[1]);
            }
            _connection.Close();
        }

        private void buttonrezervasyon_Click(object sender, EventArgs e)
        {
            listID.Items.Add(tbxID.Text);
            tbxID.Clear();
        }

        private void checkrezervasyon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkrezervasyon.Checked == true)
                tbxID.Enabled= true;
        }

        private void checktemizlik_CheckedChanged(object sender, EventArgs e)
        {
            if (checktemizlik.Checked == true)
                tbxoda.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {           
            pickertarih.Clear();
            listoda.Items.Clear();
            tbxoda.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pickertarih2.Clear();
            listID.Items.Clear();
            tbxID.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void buttonsilT_Click(object sender, EventArgs e)
        {
            prsonel.DeleteTemizlik(new Personel
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value)
            });
            dataGridView1.DataSource = prsonel.GetAllTemizlik();
        }

        private void buttonsilR_Click(object sender, EventArgs e)
        {
            prsonel.DeleteRezerve(new Personel
            {
                Id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value)
            });
            dataGridView2.DataSource = prsonel.GetAllRezerve();
        }

        private void tbxisim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
 }


