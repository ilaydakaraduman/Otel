using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Otel
{


   class PersonelBilgi
    { 
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=OTEL_PROJE;integrated security=true");

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
      
            public List<Personel> GetAllTemizlik()
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("Select * from TemizlikKayit", _connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Personel> personeller = new List<Personel>();
                while (reader.Read())
                {

                    Personel personel = new Personel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Isim_Soyad = reader["Isim_Soyad"].ToString(),
                        IslemBilgisi = reader["IslemBilgisi"].ToString(),
                        Tarih = Convert.ToDateTime(reader["Tarih"]),
                        OdaNo = Convert.ToInt16(reader["OdaNo"]),

                    };
                    personeller.Add(personel);
                }
                _connection.Close();
                return personeller;
            }


            public void AddTemizlik(Personel personel)
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("Insert into TemizlikKayit values(@Isim_Soyad,@Tarih,@IslemBilgisi,@OdaNo)", _connection);

                command.Parameters.AddWithValue("@Isim_Soyad", personel.Isim_Soyad);
                command.Parameters.AddWithValue("@Tarih", personel.Tarih);
                command.Parameters.AddWithValue("@IslemBilgisi", personel.IslemBilgisi);
                command.Parameters.AddWithValue("@OdaNo", personel.OdaNo);
                command.ExecuteNonQuery();
                _connection.Close();
            }
            public void DeleteTemizlik(Personel personel)
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("delete from TemizlikKayit where Id = @Id", _connection);
                command.Parameters.AddWithValue("@Id", personel.Id);


                command.ExecuteNonQuery();
                _connection.Close();
            }
        

        public List<Personel> GetAllRezerve()
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("Select * from RezervasyonKayit", _connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Personel> personeller = new List<Personel>();
                while (reader.Read())
                {

                    Personel personel = new Personel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Isim_Soyad = reader["Isim_Soyad"].ToString(),
                        IslemBilgisi = reader["IslemBilgisi"].ToString(),
                        Tarih = Convert.ToDateTime(reader["Tarih"]),
                        RezervasyonID = Convert.ToInt16(reader["RezervasyonID"]),
                    };
                    personeller.Add(personel);
                }
                _connection.Close();
                return personeller;
            }

            public void AddRezerve(Personel personel)
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("Insert into RezervasyonKayit values(@Isim_Soyad,@Tarih,@IslemBilgisi,@RezervasyonID)", _connection);

                command.Parameters.AddWithValue("@Isim_Soyad", personel.Isim_Soyad);
                command.Parameters.AddWithValue("@Tarih", personel.Tarih);
                command.Parameters.AddWithValue("@IslemBilgisi", personel.IslemBilgisi);
                command.Parameters.AddWithValue("@RezervasyonID", personel.RezervasyonID);
                command.ExecuteNonQuery();
                _connection.Close();
            }
        public void DeleteRezerve(Personel personel)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("delete from RezervasyonKayit where Id = @Id", _connection);
            command.Parameters.AddWithValue("@Id", personel.Id);


            command.ExecuteNonQuery();
            _connection.Close();
        }


    }
}
    


