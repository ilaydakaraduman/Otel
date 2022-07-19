using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel
{

    public partial class Odalar : Form
    {
        public Odalar()
        {
            InitializeComponent();
        }

        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=OTEL_PROJE;integrated security=true");

        public int progress1()
        {
            int sayac1 = 0;
            Color su1 = oda_1.BackColor, su2 = oda_2.BackColor, su3 = oda_6.BackColor, su4 = oda_7.BackColor, su5 = oda_11.BackColor, su6 = oda_12.BackColor;
            
             Color[] su = { su1, su2, su3, su4, su5, su6 };
            
            for (int i = 0; i < 6; i++)
            {
                if (su[i] == Color.Red)
                    sayac1++;
            }
            return sayac1;
        }
            public int progress2()
            {
            int sayac2 = 0;
            Color st1 = oda_3.BackColor, st2 = oda_4.BackColor, st3 = oda_5.BackColor, st4 = oda_8.BackColor, st5 = oda_9.BackColor, st6 = oda_10.BackColor, st7 = oda_13.BackColor, st8 = oda_14.BackColor, st9 = oda_15.BackColor;
            Color[] st = { st1, st2, st3, st4, st5, st6, st7, st8,st9 };
            for (int i = 0; i < 9; i++)
            {
                if (st[i] == Color.Red)
                    sayac2++;
            }
            return sayac2;
        }
        
        private void button16_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sayac = 0;
            _connection.Open();
            SqlCommand command = new SqlCommand("Select * from TemizlikKayit", _connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (tbxsorgutarih.Text == "")
                {
                    MessageBox.Show("Lütfen Tarih Seçiniz");
                    break;
                }
                else
                {
                    if (Convert.ToDateTime(reader["Tarih"]) == Convert.ToDateTime(tbxsorgutarih.Text))
                    {
                        ListViewItem item = new ListViewItem(reader["OdaNo"].ToString());

                        item.SubItems.Add(reader["IslemBilgisi"].ToString()+"*");
                        listView1.Items.Add(item);
                        sayac++;
                    }
                }

            }
            kayıtsayı.Text = sayac.ToString()+" kayıt bulundu." ; 
        

            _connection.Close();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            renk();
        }
        DateTime oda1, oda2, oda3, oda4, oda5, oda6, oda7, oda8, oda9, oda10, oda11, oda12, oda13, oda14, oda15;

        private void Odalar_Load(object sender, EventArgs e)
        {

        }

        DateTime oda1g, oda2g, oda3g, oda4g, oda5g, oda6g, oda7g, oda8g, oda9g, oda10g, oda11g, oda12g, oda13g, oda14g, oda15g;
        
        public void renk()
        {
            _connection.Open();
            SqlCommand command = new SqlCommand("Select * from Musteri", _connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToInt32(reader["OdaNo"]) == 1)
                    oda1 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 2)
                    oda2 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 3)
                    oda3 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 4)
                    oda4 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 5)
                    oda5 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 6)
                    oda6 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 7)
                    oda7 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 8)
                    oda8 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 9)
                    oda9 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 10)
                    oda10 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 11)
                    oda11 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 12)
                    oda12 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 13)
                    oda13 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 14)
                    oda14 = Convert.ToDateTime(reader["CikisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 15)
                    oda15 = Convert.ToDateTime(reader["CikisTarihi"]);


                if (Convert.ToInt32(reader["OdaNo"]) == 1)
                    oda1g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 2)
                    oda2g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 3)
                    oda3g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 4)
                    oda4g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 5)
                    oda5g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 6)
                    oda6g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 7)
                    oda7g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 8)
                    oda8g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 9)
                    oda9g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 10)
                    oda10g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 11)
                    oda11g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 12)
                    oda12g= Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 13)
                    oda13g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 14)
                    oda14g = Convert.ToDateTime(reader["GirisTarihi"]);
                else if (Convert.ToInt32(reader["OdaNo"]) == 15)
                    oda15g = Convert.ToDateTime(reader["GirisTarihi"]);


                if (oda1 >= Convert.ToDateTime(tbxtarih.Text) && oda1g<= Convert.ToDateTime(tbxtarih.Text))
                    oda_1.BackColor = Color.Red;
                else
                    oda_1.BackColor = Color.Transparent;

                if (oda2 >= Convert.ToDateTime(tbxtarih.Text)&&oda2g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_2.BackColor = Color.Red;
                else
                    oda_2.BackColor = Color.Transparent;

                if (oda3 >= Convert.ToDateTime(tbxtarih.Text) && oda3g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_3.BackColor = Color.Red;
                else
                    oda_3.BackColor = Color.Transparent;
                if (oda4 >= Convert.ToDateTime(tbxtarih.Text) && oda4g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_4.BackColor = Color.Red;
                else
                    oda_4.BackColor = Color.Transparent;
                if (oda5 >= Convert.ToDateTime(tbxtarih.Text) && oda5g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_5.BackColor = Color.Red;
                else
                    oda_5.BackColor = Color.Transparent;

                if (oda6 >= Convert.ToDateTime(tbxtarih.Text) && oda6g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_6.BackColor = Color.Red;
                else
                    oda_6.BackColor = Color.Transparent;
                

                if (oda7 >= Convert.ToDateTime(tbxtarih.Text) && oda7g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_7.BackColor = Color.Red;
                else
                    oda_7.BackColor = Color.Transparent;

                if (oda8 >= Convert.ToDateTime(tbxtarih.Text) && oda8g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_8.BackColor = Color.Red;
                else
                    oda_8.BackColor = Color.Transparent;

                if (oda9 >= Convert.ToDateTime(tbxtarih.Text) && oda9g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_9.BackColor = Color.Red;
                else
                    oda_9.BackColor = Color.Transparent;
                if (oda10 >= Convert.ToDateTime(tbxtarih.Text) && oda10g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_10.BackColor = Color.Red;
                else
                    oda_10.BackColor = Color.Transparent;

                if (oda11 >= Convert.ToDateTime(tbxtarih.Text) && oda11g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_11.BackColor = Color.Red;
                else
                    oda_11.BackColor = Color.Transparent;

                if (oda12 >= Convert.ToDateTime(tbxtarih.Text) && oda12g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_12.BackColor = Color.Red;
                else
                    oda_12.BackColor = Color.Transparent;
                if (oda13 >= Convert.ToDateTime(tbxtarih.Text) && oda13g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_13.BackColor = Color.Red;
                else
                    oda_13.BackColor = Color.Transparent;
                if (oda14 >= Convert.ToDateTime(tbxtarih.Text) && oda14g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_14.BackColor = Color.Red;
                else
                    oda_14.BackColor = Color.Transparent;

                if (oda15 >= Convert.ToDateTime(tbxtarih.Text) && oda15g <= Convert.ToDateTime(tbxtarih.Text))
                    oda_15.BackColor = Color.Red;
                else
                    oda_15.BackColor = Color.Transparent;
              
            }
            _connection.Close();
        }
           

        }
    }


