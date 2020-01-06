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
    /// Interaction logic for AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Window
    {
        int PatientID=-1;
        public AppointmentPage()
        {
            InitializeComponent();
        }

        private void btn_PatientAdd_Click(object sender, RoutedEventArgs e)
        {
            Patients pat = new Patients();
            pat.Name = textBox_PatientName.Text;
            pat.Surname = textBox_PatientSurname.Text;
            PatientID = pat.Id;

            HospitalDB db = new HospitalDB();
            db.Patients.Add(pat);

            db.SaveChanges();
            MessageBox.Show("Patient is saved...");
            textBox_PatientName.Text = "";
            textBox_PatientSurname.Text = "";
        }

        private void btn_take_appo_Click(object sender, RoutedEventArgs e)
        {
            if(PatientID == -1)
            {
                MessageBox.Show("Before taking appointment. You should add a patient.");
                return;
            }
            Appointments appointment = new Appointments();
            appointment.AppointmentHour = Int32.Parse(textbox_take_appo_hour.Text);
            appointment.AppointmentSubjectId = Int32.Parse(textBox_take_appo_subject_id.Text);
            appointment.AppointmentDate = date_picker_take_appointment.SelectedDate.Value;
            appointment.DoctorId = Int32.Parse(textbox_take_appo_doctor_id.Text);
            appointment.PatientId = PatientID;
            appointment.DoctorNotes = "";

            HospitalDB db = new HospitalDB();
            List<Appointments> appointmentList = db.Appointments.ToList();

            foreach (Appointments appo in appointmentList)
            {
                if(appo.AppointmentDate == appointment.AppointmentDate)
                {
                    if(appo.AppointmentHour == appointment.AppointmentHour)
                    {
                        MessageBox.Show("Selected date is reserved. Try different time");
                        return;
                    }
                }
            }
            db.Appointments.Add(appointment);

            db.SaveChanges();
            MessageBox.Show("Appointment is saved...");
            textbox_take_appo_hour.Text = "";
            textBox_take_appo_subject_id.Text = "";
            textbox_take_appo_doctor_id.Text = "";
            date_picker_take_appointment.SelectedDate = DateTime.Now;
        }

        private void LoadSubjects()
        {
            HospitalDB db = new HospitalDB();
            List<Subjects> subjectList = db.Subjects.ToList();
            data_grid_take_appo_subject_list.ItemsSource = subjectList;
        }

        private void form_take_appo_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSubjects();
        }
    }
}
