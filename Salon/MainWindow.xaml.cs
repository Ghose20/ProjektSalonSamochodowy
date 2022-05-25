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

            c.imie = txtboxFirstName.Text;
            c.nazwisko = txtboxLastName.Text;
            c.Pesel = txtboxPesel.Text;
            c.email = txtboxemail.Text;
            c.telefon = txtboxContactNumber.Text;


            bool success = c.Insert(c);
            if (success == true)
            {

                System.Windows.MessageBox.Show("Pomyslnie dodano nowego klienta");

                Clear();
            }
            else
            {

                System.Windows.MessageBox.Show("Nie udalo sie dodac klienta");
            }

            DataTable dt = c.Select();
            dgvklienci.ItemsSource = dt.DefaultView;
        }
        public void Clear()
        {
            txtboxID.Text = "";
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtboxPesel.Text = "";
            txtboxemail.Text = "";
            txtboxContactNumber.Text = "";

        }
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
    }
}
