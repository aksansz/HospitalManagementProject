using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalManagement
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

        private void label_appointment_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Clicked");
        }

        private void label_lookat_doctors_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Clicked");
        }

        private void btn_doctor_login_Click(object sender, RoutedEventArgs e)
        {
            image_welcome.Visibility = Visibility.Hidden;
            label_password.Visibility = Visibility.Visible;
            label_username.Visibility = Visibility.Visible;
            textbox_username.Visibility = Visibility.Visible;
            textbox_password.Visibility = Visibility.Visible;
            btn_doctor_login_bottom.Visibility = Visibility.Visible;
        }

        private void btn_admin_login_Click(object sender, RoutedEventArgs e)
        {
            image_welcome.Visibility = Visibility.Hidden;
            label_password.Visibility = Visibility.Visible;
            label_username.Visibility = Visibility.Visible;
            textbox_username.Visibility = Visibility.Visible;
            textbox_password.Visibility = Visibility.Visible;
            btn_admin_login_bottom.Visibility = Visibility.Visible;
        }

        private void btn_doctor_login_bottom_Click(object sender, RoutedEventArgs e)
        {
            image_welcome.Visibility = Visibility.Visible;
            label_password.Visibility = Visibility.Hidden;
            label_username.Visibility = Visibility.Hidden;
            textbox_username.Visibility = Visibility.Hidden;
            textbox_password.Visibility = Visibility.Hidden;
            btn_doctor_login_bottom.Visibility = Visibility.Hidden;
        }

        private void btn_admin_login_bottom_Click(object sender, RoutedEventArgs e)
        {
            image_welcome.Visibility = Visibility.Visible;
            label_password.Visibility = Visibility.Hidden;
            label_username.Visibility = Visibility.Hidden;
            textbox_username.Visibility = Visibility.Hidden;
            textbox_password.Visibility = Visibility.Hidden;
            btn_admin_login_bottom.Visibility = Visibility.Hidden;
            if (textbox_username.Text=="admin")
            {
                if(textbox_password.Text == "1234")
                {
                    AdminHomePage adminPage = new AdminHomePage();
                    adminPage.Show();
                }
                else
                {
                    MessageBox.Show("Password is wrong. Try again.");
                }
            }
            else
            {
                MessageBox.Show(textbox_username.Text + " cannot be found. Try again.");
            }
            textbox_username.Text = "";
            textbox_password.Text = "";
        }

        private void form_main_window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void LoadDoctors()
        {
            HospitalDB db = new HospitalDB();
            List<Doctors> doctorList = db.Doctors.ToList();
        }
    }
}
