using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Salon.SalonClass;
using System.Configuration;
using System.Data.SqlClient;


namespace Salon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        salonClass c = new salonClass();
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Pobranie wartości z pól
            c.imie = txtboxFirstName.Text;
            c.nazwisko = txtboxLastName.Text;
            c.Pesel = txtboxPesel.Text;
            c.email = txtboxemail.Text;
            c.telefon = txtboxContactNumber.Text;

            // Dodanie wartości do bazy przy użyciu metody insert
            bool success = c.Insert(c);
            if (success == true)
            {
                // udalo sie dodac
                System.Windows.MessageBox.Show("Pomyslnie dodano nowego klienta");
                // wywołanie metody Clear
                Clear();
            }
            else
            {
                // nie udalo sie dodac
                System.Windows.MessageBox.Show("Nie udalo sie dodac klienta");
            }
            // wczytanie danych do Data GridView
            DataTable dt = c.Select();
            dgvklienci.ItemsSource = dt.DefaultView;
        }
        // Metoda do czysczenia pól
        public void Clear()
        {
            txtboxID.Text = "";
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtboxPesel.Text = "";
            txtboxemail.Text = "";
            txtboxContactNumber.Text = "";

        }
        // wyswietlanie w DataGrid
        private void dgvklienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.DataGrid gd = (System.Windows.Controls.DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txtboxID.Text = row_selected["ID"].ToString();
                txtboxFirstName.Text = row_selected["Imie"].ToString();
                txtboxLastName.Text = row_selected["Nazwisko"].ToString();
                txtboxPesel.Text = row_selected["Pesel"].ToString();
                txtboxemail.Text = row_selected["Email"].ToString();
                txtboxContactNumber.Text = row_selected["Telefon"].ToString();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            // wywolanie metody Clear
            Clear();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // pobranie ID z aplikacji
            c.ID = Convert.ToInt32(txtboxID.Text);
            
            bool success = c.Delete(c);

            if (success == true)
            {
                // udalo sie usunac 
                System.Windows.MessageBox.Show("Pomyślnie usunieto klienta");
                // wyswietlenie wartosci w DataGrid
                DataTable dt = c.Select();
                dgvklienci.ItemsSource = dt.DefaultView;
                // wywolanie metody Clear
                Clear();
            }


            else
            {
                // nie udalo sie usunac
                System.Windows.MessageBox.Show("Nie udało sie usunąć klienta");
            }
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        private void txtboxSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // pobranie wartosci z pól
            string keyword = txtboxSearch.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            // wyszukanie po imieniu lub nazwisku lub po numerze pesel
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Klienci WHERE imie LIKE '%" + keyword + "%' OR Nazwisko LIKE '%" + keyword + "%' OR Pesel LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvklienci.ItemsSource = dt.DefaultView;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Pobranie wartości z pól
            c.ID = int.Parse(txtboxID.Text);
            c.imie = txtboxFirstName.Text;
            c.nazwisko = txtboxLastName.Text;
            c.Pesel = txtboxPesel.Text;
            c.email = txtboxemail.Text;
            c.telefon = txtboxContactNumber.Text;

            // zaaktualizowanie wartosci w bazie danych
            bool success = c.Update(c);
            if (success == true)
            {
                // udalo sie
                System.Windows.MessageBox.Show("Dane klienta zostaly zaakutalizowane pomyślnie");
                // wczytanie danych do Data GridView
                DataTable dt = c.Select();
                dgvklienci.ItemsSource = dt.DefaultView;
                // wywolanie metody Clear
                Clear();
            }
            else
            {
                // nie udalo sie dodac
                System.Windows.MessageBox.Show("Nie udało sie zaaktualizować danych klienta");
            }

        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // wczytanie danych do Data GridView
            DataTable dt = c.Select();
            dgvklienci.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // przejscie do kolejnego okna aplikacji
            okno1 win2 = new okno1();
            win2.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // zamykanie aplikacji
            Close();
        }
    }
}
