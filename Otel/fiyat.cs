using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Otel
{
    public class fiyat
    {
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=OTEL_PROJE;integrated security=true");
        private double standart = 100, suit = 200;
        private double tek = 1, cift = 2, aile = 4;
        private double fiyatt;
        private double herseydahil = 1, ultradahil = 1.5, yarimpansiyon = 0.5; 
         public double Standart
        {
            get { return standart; }
            set { standart = value; }
        }
        public double Suit
        {
            get { return suit; }
            set { suit = value; }
        }
        public double Tek
        {
            get { return tek; }
            set { tek = value; }
        }
        public double Cift
        {
            get { return cift; }
            set { cift = value; }
        }
        public double Aile
        {
            get { return aile; }
            set { aile = value; }
        }
        public double Fiyat
        {
            get { return fiyatt; }
            set { fiyatt = value; }
        }
        public double HerseyDahil
        {
            get { return herseydahil; }
            set { herseydahil = value; }
        }
        public double Ultradahil
        {
            get { return ultradahil; }
            set { ultradahil = value; }
        }
        public double Yarimpansiyon
        {
            get { return yarimpansiyon; }
            set { yarimpansiyon = value; }


        }
        }
    }




  

