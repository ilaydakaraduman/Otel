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
    public partial class tbxtel : Form
    {
        public tbxtel()
        {
            InitializeComponent();
        }
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=OTEL_PROJE;integrated security=true");

        public bool kontroller()
        {
            bool durum = true;
            int sayac = 0;
            string metin = tbxposta.Text.ToString();
            for (int i = 0; i < tbxposta.Text.Length; i++)
            {
                if (metin[i] != '@')
                    sayac++;
            }
            if (tbxad.Text == "" || tbxsoyad.Text == "" || tbxposta.Text == "" || tbxtc.Text == "" || tbxkonsept.Text == ""
                || tbxgiris.Text == "" || tbxcıkıs.Text == "" || tbxfiyat.Text == "" || tbxno.Text == ""
                || tbxcocuk.Text == "" || tbxttel.Text == "" || tbxyetiskin.Text == "" || combocinsiyet.Text == "")
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz.");
                durum = false;
            }
            else if (müsait() == false)
            {
                MessageBox.Show("Girilen Tarihlerde Seçilen Oda Rezerve Edilmiştir.");
                durum = false;
            }
           else if (sayac == tbxposta.Text.Length)
            {
               MessageBox.Show("Hatalı e-posta girişi");
                durum = false;
            }

            return durum;
        }
        public bool müsait()
        {
            _connection.Open();
            bool durum = true;

            SqlCommand command = new SqlCommand("Select * from Musteri", _connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                    if (reader["Isim"].ToString() != tbxad.Text &&reader["Soyad"].ToString() != tbxsoyad.Text && Convert.ToInt32(reader["OdaNo"]) == Convert.ToInt32(tbxno.Text))
                    {
                        if (Convert.ToDateTime(tbxgiris.Text) < Convert.ToDateTime(reader["CikisTarihi"]) && Convert.ToDateTime(tbxcıkıs.Text) > Convert.ToDateTime(reader["GirisTarihi"]))
                        {
                            durum = false;
                        }
                    }
                
                
            }
            _connection.Close();
            return durum;
        }    
        MusteriBilgi mstri = new MusteriBilgi();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = mstri.GetAll();
        }
      
        private void btnekle_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (kontroller() == true)
                { 
                        mstri.Add(new Musteri
                    {
                        Isim = tbxad.Text,
                        Soyad = tbxsoyad.Text,
                        Cinsiyet = combocinsiyet.Text,
                        DogumTarihi = Convert.ToDateTime((tbxtarih.Text)),
                        Tc = tbxtc.Text,
                        Eposta = tbxposta.Text,
                        Tel = tbxttel.Text,
                        OdaNo = Convert.ToInt32(tbxno.Text),
                        OdaTipi = tbxtip.Text,
                        YetiskinSayisi = Convert.ToInt32(tbxyetiskin.Text),
                        CocukSayisi = Convert.ToInt32(tbxcocuk.Text),
                        Konsept = tbxkonsept.Text,
                        GirisTarihi = Convert.ToDateTime((tbxgiris.Text)),
                        CikisTarihi = Convert.ToDateTime((tbxcıkıs.Text)),
                        Fiyat = Convert.ToInt32(tbxfiyat.Text)
                    });
                    dataGridView1.DataSource = mstri.GetAll();
                }

            }
            catch(Exception hata)
            {                
                MessageBox.Show(hata.Message);
            }
          
        }
        private void btnsil_Click_1(object sender, EventArgs e)
        {
            mstri.Delete(new Musteri
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)
            });
            dataGridView1.DataSource = mstri.GetAll();
        }
        private void btngüncelle_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                if (kontroller() == true)
                {
                        mstri.Update(new Musteri
                    {
                        Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                        Isim = tbxad.Text,
                        Soyad = tbxsoyad.Text,
                        Cinsiyet = combocinsiyet.Text,
                        DogumTarihi = DateTime.Parse(tbxtarih.Text),
                        Tc = tbxtc.Text,
                        Eposta = tbxposta.Text,
                        Tel = tbxttel.Text,
                        OdaNo = Convert.ToInt32(tbxno.Text),
                        OdaTipi = tbxtip.Text,
                        YetiskinSayisi = Convert.ToInt32(tbxyetiskin.Text),
                        CocukSayisi = Convert.ToInt32(tbxcocuk.Text),
                        Konsept = tbxkonsept.Text,
                        GirisTarihi = DateTime.Parse(tbxgiris.Text),
                        CikisTarihi = DateTime.Parse(tbxcıkıs.Text),
                        Fiyat = Convert.ToInt32(tbxfiyat.Text),

                    });
                    dataGridView1.DataSource = mstri.GetAll();
                }
                
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void tbxtc_TextChanged(object sender, EventArgs e)
        {
            if (tbxtc.TextLength < 11 || tbxtc.TextLength > 11)
                errorProvider1.SetError(tbxtc, "Tc Kimlik No 11 Haneli Olmalıdır!");
            else
                errorProvider1.Clear();
        }       
        TimeSpan gun;
        fiyat f = new fiyat();
        public double hesap()
        {
            gun = Convert.ToDateTime(tbxcıkıs.Text) - Convert.ToDateTime(tbxgiris.Text);
            if (Convert.ToInt32(tbxno.Text) == 1 || Convert.ToInt32(tbxno.Text) == 6 || Convert.ToInt32(tbxno.Text) == 11)
                f.Fiyat = f.Tek * f.Suit * gun.Days;
            if (Convert.ToInt32(tbxno.Text) == 2 || Convert.ToInt32(tbxno.Text) == 7 || Convert.ToInt32(tbxno.Text) == 12)
                f.Fiyat = f.Aile * f.Suit * gun.Days;
            if (Convert.ToInt32(tbxno.Text) == 3 || Convert.ToInt32(tbxno.Text) == 8 || Convert.ToInt32(tbxno.Text) == 13)
                f.Fiyat = f.Tek * f.Standart * gun.Days;
            if (Convert.ToInt32(tbxno.Text) == 4 || Convert.ToInt32(tbxno.Text) == 9 || Convert.ToInt32(tbxno.Text) == 14)
                f.Fiyat = f.Cift * f.Standart * gun.Days;
            if (Convert.ToInt32(tbxno.Text) == 5 || Convert.ToInt32(tbxno.Text) == 10 || Convert.ToInt32(tbxno.Text) == 15)
                f.Fiyat = f.Aile * f.Standart * gun.Days;
            return f.Fiyat;
        }

            public double islem()
            {
                double konseptliF;
                if (tbxkonsept.Text == "Her şey Dahil")
                    konseptliF = hesap() * f.HerseyDahil;
                else if (tbxkonsept.Text == "Ultra Her şey Dahil")
                    konseptliF = hesap() * f.HerseyDahil;
                else
                    konseptliF = hesap() * f.Yarimpansiyon;
                return konseptliF;
            }
        
        private void buttonfgoster_Click(object sender, EventArgs e)
        {          
            tbxfiyat.Text = islem().ToString();
        }
        Odalar oda = new Odalar();
        private void button1_Click(object sender, EventArgs e)
        {
            oda.Show();
            button2.Enabled = true;
        }
           private void button2_Click(object sender, EventArgs e)
        {         
            progressStandart.Value = oda.progress2();
            stkalan.Text = "Son " + (progressStandart.Maximum - oda.progress2()) + " standart oda kaldı";
            progressSuit.Value = oda.progress1();
            sukalan.Text = "Son " + (progressSuit.Maximum - oda.progress1()) + " suit oda kaldı";
        }
       
        private void tbxno_Click(object sender, EventArgs e)
        {             
                int toplamkisi = Convert.ToInt32(tbxyetiskin.Value) + Convert.ToInt32(tbxcocuk.Value);
                string[] suittek = { "1", "6", "11" };
                string[] suitaile = { "2", "7", "12" };
                string[] tekstandart = { "3", "8", "13" };
                string[] ciftstandart = { "4", "9", "14" };
                string[] ailestandart = { "5", "10", "15" };
                if (tbxtip.Text == "Standart" && toplamkisi >= 3)
                {
                    tbxno.Items.Clear();
                    tbxno.Items.AddRange(ailestandart);
                }
                else if (tbxtip.Text == "Suit" && toplamkisi >= 3)
                {
                    tbxno.Items.Clear();
                    tbxno.Items.AddRange(suitaile);
                }
                else if (tbxtip.Text == "Standart" && toplamkisi == 2)
                {
                    tbxno.Items.Clear();
                    tbxno.Items.AddRange(ciftstandart);
                }
                else if (tbxtip.Text == "Standart" && toplamkisi == 1)
                {
                    tbxno.Items.Clear();
                    tbxno.Items.AddRange(tekstandart);
                }
                else if (tbxtip.Text == "Suit" && toplamkisi == 1)
                {
                    tbxno.Items.Clear();
                    tbxno.Items.AddRange(suittek);
                }
                else
                {
                    MessageBox.Show("Kritere Uygun Oda Bulunamadı");
                }
            
            
          
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            tbxad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            combocinsiyet.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxtarih.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxtc.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbxttel.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tbxposta.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            tbxtip.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            tbxkonsept.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            tbxno.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            tbxyetiskin.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            tbxcocuk.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            tbxgiris.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            tbxcıkıs.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            tbxfiyat.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
        }

        
    }
}