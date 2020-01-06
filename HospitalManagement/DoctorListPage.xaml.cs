using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalManagement
{
    /// <summary>
    /// Interaction logic for DoctorListPage.xaml
    /// </summary>
    public partial class DoctorListPage : Window
    {
        public DoctorListPage()
        {
            InitializeComponent();
        }

        private void LoadDoctors()
        {
            HospitalDB db = new HospitalDB();
            List<Doctors> doctorList = db.Doctors.ToList();
            datagrid_doctor_list.ItemsSource = doctorList;
        }

        private void form_doctor_list_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDoctors();
        }
    }
}
