using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Salon.SalonClass
{
    internal class salonClass
    {
        // wlasciwosci get i set
        public int ID { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string Pesel { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        
        // Wybranie danych z bazy danych
        public DataTable Select()
        {
            // polaczenie z baza
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                // zapytanie SQL
                string sql = "SELECT * FROM Klienci";
                // tworzenie cmd przy uzyciu sql i conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                // tworzenie SQL DataAdapter przy uzyciu cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // zamkniecie polaczenia z baza
                conn.Close();
            }
            return dt;

        }
        // dodanie wartosci do bazy danych
        public bool Insert(salonClass c)
        {
            // tworzenie domyslnego typu zwracanego i nadanie mu wartosci false
            bool isSuccess = false;

            // polaczenie z baza danych
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                // zapytanie SQL dodajace wartosci do tabeli
                string sql = "INSERT INTO klienci (Imie, Nazwisko, Pesel, Email, Telefon) VALUES (@imie, @nazwisko, @pesel, @email, @telefon)";
                // tworzenie cmd przy uzyciu sql i conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                // tworzenie parametrow zeby dodac dane 
                cmd.Parameters.AddWithValue("@Imie", c.imie);
                cmd.Parameters.AddWithValue("@Nazwisko", c.nazwisko);
                cmd.Parameters.AddWithValue("@Pesel", c.Pesel);
                cmd.Parameters.AddWithValue("@Email", c.email);
                cmd.Parameters.AddWithValue("@Telefon", c.telefon);

                // otwarcie polaczenia z baza
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // jesli zapytanie wykona sie poprawnie wtedy wartosc wiersza bedzie wieksza od zera w przeciwnym wypadku bedzie zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // zamkniecie polaczenia z baza
                conn.Close();
            }
            return isSuccess;
        }
        // metoda do zaaktualizowania danych w aplikacji
        public bool Update(salonClass c)
        {
            // tworzenie domyslnego typu zwracanego i nadanie mu wartosci false
            bool isSuccess = false;
            // polaczenie z baza danych
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                // tworzenie zapytania ktore zaakutalizuje dane w bazie
                string sql = "UPDATE klienci SET Imie=@imie, Nazwisko=@nazwisko, Pesel=@pesel, Email=@email, Telefon=@telefon WHERE ID=@ID";
                // tworzenie SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                // tworzenie parametrow aby dodac wartosc
                cmd.Parameters.AddWithValue("@Imie", c.imie);
                cmd.Parameters.AddWithValue("@Nazwisko", c.nazwisko);
                cmd.Parameters.AddWithValue("@Pesel", c.Pesel);
                cmd.Parameters.AddWithValue("@Email", c.email);
                cmd.Parameters.AddWithValue("@Telefon", c.telefon);
                cmd.Parameters.AddWithValue("@ID", c.ID);
                // otwarcie polaczenia z baza
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                // jesli zapytanie wykona sie poprawnie wtedy wartosc wiersza bedzie wieksza od zera w przeciwnym wypadku bedzie zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // zamkniecie polaczenia z baza
                conn.Close();
            }
            return isSuccess;
        }
        // metoda do usuwania wartosci z bazy
        public bool Delete(salonClass c)
        {
            // tworzenie domyslnego typu zwracanego i nadanie mu wartosci false
            bool isSuccess = false;
            // polaczenie z baza danych
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                // zapytanie SQL do usuniecia wartosci
                string sql = "DELETE FROM klienci WHERE ID=@ID";

                // tworzenie SQl Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", c.ID);
                // otwarcie polaczenia z baza
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // jesli zapytanie wykona sie poprawnie wtedy wartosc wiersza bedzie wieksza od zera w przeciwnym wypadku bedzie zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // zamkniecie polaczenia z baza
                conn.Close();
            }
            return isSuccess;
        }
    }
}
