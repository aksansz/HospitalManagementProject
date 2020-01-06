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

        }

        private void btn_admin_login_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
