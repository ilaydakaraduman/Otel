using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel
{

    public class MusteriBilgi
    {

        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=OTEL_PROJE;integrated security=true");
       
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public List<Musteri> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Musteri", _connection);
            

            SqlDataReader reader = command.ExecuteReader();
            List<Musteri> musteriler = new List<Musteri>();
            while (reader.Read())
            {

                Musteri musteri = new Musteri
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Isim = reader["Isim"].ToString(),
                    Soyad = reader["Soyad"].ToString(),
                    Cinsiyet = reader["Cinsiyet"].ToString(),
                    DogumTarihi = Convert.ToDateTime(reader["DogumTarihi"]),
                    Tc = reader["Tc"].ToString(),
                    Tel = reader["Tel"].ToString(),
                    Eposta = reader["Eposta"].ToString(),
                    OdaTipi = reader["OdaTipi"].ToString(),
                    Konsept = reader["Konsept"].ToString(),
                    OdaNo = Convert.ToInt32(reader["OdaNo"]),
                    YetiskinSayisi = Convert.ToInt32(reader["YetiskinSayisi"]),
                    CocukSayisi = Convert.ToInt32(reader["CocukSayisi"]),
                    GirisTarihi = Convert.ToDateTime(reader["GirisTarihi"]),
                    CikisTarihi = Convert.ToDateTime(reader["CikisTarihi"]),
                    Fiyat = Convert.ToInt32(reader["Fiyat"])

                };           
                musteriler.Add(musteri);
            }
            _connection.Close();
            return musteriler;
        }      
        public void Add(Musteri musteri)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Insert into Musteri values(@Isim,@Soyad,@Cinsiyet,@DogumTarihi,@Tc,@Tel,@Eposta,@OdaTipi,@Konsept,@OdaNo,@YetiskinSayisi,@CocukSayisi,@GirisTarihi,@CikisTarihi,@Fiyat )", _connection);
            
            command.Parameters.AddWithValue("@Isim", musteri.Isim);
            command.Parameters.AddWithValue("@Soyad", musteri.Soyad);
            command.Parameters.AddWithValue("@Cinsiyet", musteri.Cinsiyet);
            command.Parameters.AddWithValue("@DogumTarihi", musteri.DogumTarihi);
            command.Parameters.AddWithValue("@Tc", musteri.Tc);
            command.Parameters.AddWithValue("@Tel", musteri.Tel);
            command.Parameters.AddWithValue("@Eposta", musteri.Eposta);
            command.Parameters.AddWithValue("@OdaTipi", musteri.OdaTipi);
            command.Parameters.AddWithValue("@Konsept", musteri.Konsept);
            command.Parameters.AddWithValue("@OdaNo", musteri.OdaNo);
            command.Parameters.AddWithValue("@YetiskinSayisi", musteri.YetiskinSayisi);
            command.Parameters.AddWithValue("@CocukSayisi", musteri.CocukSayisi);
            command.Parameters.AddWithValue("@GirisTarihi", musteri.GirisTarihi);
            command.Parameters.AddWithValue("@CikisTarihi", musteri.CikisTarihi);
            command.Parameters.AddWithValue("@Fiyat", musteri.Fiyat);
            command.ExecuteNonQuery();
            _connection.Close();
        }
            public void Delete(Musteri musteri)
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("delete from Musteri where Id = @Id", _connection);
                command.Parameters.AddWithValue("@Id", musteri.Id);


                command.ExecuteNonQuery();
                _connection.Close();
            }
            public void Update(Musteri musteri)
            {
            ConnectionControl();
                SqlCommand command = new SqlCommand("update Musteri set Isim= @Isim,Soyad = @Soyad,Cinsiyet = @Cinsiyet,DogumTarihi = @DogumTarihi,Tc= @Tc,Tel= @Tel,Eposta =@Eposta, OdaTipi= @OdaTipi,Konsept= @Konsept,OdaNo= @OdaNo,YetiskinSayisi= @YetiskinSayisi,CocukSayisi= @CocukSayisi,GirisTarihi= @GirisTarihi,CikisTarihi= @CikisTarihi, Fiyat= @Fiyat where Id =@Id", _connection);
                command.Parameters.AddWithValue("@Isim", musteri.Isim);
                command.Parameters.AddWithValue("@Soyad", musteri.Soyad);
                command.Parameters.AddWithValue("@DogumTarihi", musteri.DogumTarihi);
                command.Parameters.AddWithValue("@Cinsiyet", musteri.Cinsiyet);
                command.Parameters.AddWithValue("@Tc", musteri.Tc);
                command.Parameters.AddWithValue("@Tel", musteri.Tel);
                command.Parameters.AddWithValue("@Eposta", musteri.Eposta);
            command.Parameters.AddWithValue("@OdaTipi", musteri.OdaTipi);
            command.Parameters.AddWithValue("@Konsept", musteri.Konsept);
            command.Parameters.AddWithValue("@OdaNo", musteri.OdaNo);
            command.Parameters.AddWithValue("@YetiskinSayisi", musteri.YetiskinSayisi);
            command.Parameters.AddWithValue("@CocukSayisi", musteri.CocukSayisi);
            command.Parameters.AddWithValue("@GirisTarihi", musteri.GirisTarihi);
            command.Parameters.AddWithValue("@CikisTarihi", musteri.CikisTarihi);
            command.Parameters.AddWithValue("@Fiyat", musteri.Fiyat);
            command.Parameters.AddWithValue("@Id", musteri.Id);
            command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }





