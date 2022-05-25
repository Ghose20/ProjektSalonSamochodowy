using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salon.SalonClass
{
    internal class salonClass
    {
        public int ID { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string Pesel { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public DataTable Select()
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {

                string sql = "SELECT * FROM Klienci";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }
    }
}
