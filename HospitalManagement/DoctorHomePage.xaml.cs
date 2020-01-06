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
    /// Interaction logic for DoctorHomePage.xaml
    /// </summary>
    public partial class DoctorHomePage : Window
    {
        Doctors doc;
        public DoctorHomePage(Doctors doctor)
        {
            InitializeComponent();
            doc = doctor;
            label_doctor_welcome_message.Content = "Welcome Doctor " + doc.Name + " " + doc.Surname;
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            HospitalDB db = new HospitalDB();
            List<Appointments> appointmentList = db.Appointments.ToList();
            List<Appointments> newAppointmentList = new List<Appointments>();
            foreach (Appointments appo in appointmentList)
            {
                if(appo.DoctorId == doc.Id)
                {
                    newAppointmentList.Add(appo);
                }
            }
            data_grid_doctorpage_appointmentList.ItemsSource = newAppointmentList;
        }

        private void data_grid_doctorpage_appointmentList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Appointments appointment = data_grid_doctorpage_appointmentList.SelectedItem as Appointments;
            if (appointment != null)
            {
                textbox_doctor_notes.Text = appointment.DoctorNotes;
            }
        }

        private void btn_update_doctor_notes_click(object sender, RoutedEventArgs e)
        {
            Appointments appointment = data_grid_doctorpage_appointmentList.SelectedItem as Appointments;
            if (appointment != null)
            {
                HospitalDB db = new HospitalDB();
                var appointmentnew = db.Appointments.Find(appointment.Id);
                appointmentnew.DoctorNotes = textbox_doctor_notes.Text;
                db.SaveChanges();
                LoadAppointments();
                MessageBox.Show("Updated.");
            }
            else
            {
                MessageBox.Show("to update. You should select an appointment.");
            }
        }
    }
}
