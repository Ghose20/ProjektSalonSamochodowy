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

    }
}
