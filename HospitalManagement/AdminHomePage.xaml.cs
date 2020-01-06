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
    /// Interaction logic for AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : Window
    {
        public AdminHomePage()
        {
            InitializeComponent();
        }

        private void form_admin_homepage_Loaded(object sender, RoutedEventArgs e)
        {
            fillSubjectCombobox();
            LoadDoctors();
            LoadSubjects();
            LoadAppointments();
        }

        private void fillSubjectCombobox()
        {
            HospitalDB db = new HospitalDB();
            List<Subjects> subjectList = db.Subjects.ToList();
            foreach (Subjects subject in subjectList)
            {
                combobox_doctorSubject.Items.Add(subject.Name);
            }
            combobox_doctorSubject.SelectedIndex = 0;
        }

        private void LoadDoctors()
        {
            HospitalDB db = new HospitalDB();
            List<Doctors> doctorList = db.Doctors.ToList();
            grid_doctors.ItemsSource = doctorList;
        }

        private void LoadSubjects()
        {
            HospitalDB db = new HospitalDB();
            List<Subjects> subjectList = db.Subjects.ToList();
            grid_subjects.ItemsSource = subjectList;
            fillSubjectCombobox();
        }

        private void LoadAppointments()
        {
            HospitalDB db = new HospitalDB();
            List<Appointments> appointmentList = db.Appointments.ToList();
            grid_appointments.ItemsSource = appointmentList;
        }

        private void btn_doctor_insert_click(object sender, RoutedEventArgs e)
        {
            HospitalDB db1 = new HospitalDB();
            List<Subjects> subjectList = db1.Subjects.ToList();
            Doctors doctor = new Doctors();
            doctor.Name = textbox_doctorName.Text;
            doctor.Surname = textbox_doctorSurname.Text;
            doctor.SubjectName = (string)combobox_doctorSubject.SelectedItem;
            doctor.BirthDate = datePicker_doctor_birthDate.SelectedDate.Value;
            doctor.username = textbox_doctor_username.Text;
            doctor.password = textbox_doctor_password.Text;

            HospitalDB db = new HospitalDB();
            db.Doctors.Add(doctor);

            db.SaveChanges();
            MessageBox.Show("Doctor is saved...");
            textbox_doctorName.Text = "";
            textbox_doctorSurname.Text = "";
            textbox_doctor_username.Text = "";
            textbox_doctor_password.Text = "";
            datePicker_doctor_birthDate.SelectedDate = DateTime.Now;
            LoadDoctors();
        }

        private void btn_doctor_update_click(object sender, RoutedEventArgs e)
        {
            Doctors doctor = grid_doctors.SelectedItem as Doctors;
            if (doctor != null)
            {
                HospitalDB db = new HospitalDB();
                var doctornew = db.Doctors.Find(doctor.Id);
                doctornew.Name = textbox_doctorName.Text;
                doctornew.Surname = textbox_doctorSurname.Text;
                doctornew.BirthDate = datePicker_doctor_birthDate.SelectedDate.Value;
                doctornew.SubjectName = (string)combobox_doctorSubject.SelectedItem;
                doctornew.username = textbox_doctor_username.Text;
                doctornew.password = textbox_doctor_password.Text;
                db.SaveChanges();
                LoadDoctors();
                MessageBox.Show("Updated.");
            }
            else
            {
                MessageBox.Show("to update. You should select a doctor.");
            }
        }

        private void grid_doctors_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Doctors doctor = grid_doctors.SelectedItem as Doctors;
            if (doctor != null)
            {
                textbox_doctorName.Text = doctor.Name;
                textbox_doctorSurname.Text = doctor.Surname;
                datePicker_doctor_birthDate.SelectedDate = doctor.BirthDate;
                textbox_doctor_username.Text = doctor.username;
                textbox_doctor_password.Text = doctor.password;
            }
        }

        private void btn_doctor_delete_Click(object sender, RoutedEventArgs e)
        {
            Doctors doctor = grid_doctors.SelectedItem as Doctors;
            if (doctor != null)
            {
                HospitalDB db = new HospitalDB();
                db.Doctors.Remove(doctor);
                db.SaveChanges();
                MessageBox.Show("Doctor is deleted!!");
                LoadDoctors();

            }
            else
            {
                MessageBox.Show("to delete. You should select a doctor");
            }
        }

        private void btn_subject_insert_click(object sender, RoutedEventArgs e)
        {
            Subjects subject = new Subjects();
            subject.Name = textbox_subjectName.Text;

            HospitalDB db = new HospitalDB();
            db.Subjects.Add(subject);

            db.SaveChanges();
            MessageBox.Show("Subject is saved...");
            textbox_subjectName.Text = "";
            LoadSubjects();
        }

        private void btn_subject_update_click(object sender, RoutedEventArgs e)
        {
            Subjects subject = grid_subjects.SelectedItem as Subjects;
            if (subject != null)
            {
                HospitalDB db = new HospitalDB();
                var subjectnew = db.Subjects.Find(subject.Id);
                subjectnew.Name = textbox_subjectName.Text;
                db.SaveChanges();
                LoadSubjects();
                MessageBox.Show("Updated.");
            }
            else
            {
                MessageBox.Show("to update. You should select a doctor.");
            }
        }

        private void btn_subject_delete_Click(object sender, RoutedEventArgs e)
        {
            Subjects subject = grid_subjects.SelectedItem as Subjects;
            if (subject != null)
            {
                HospitalDB db = new HospitalDB();
                db.Subjects.Remove(subject);
                db.SaveChanges();
                MessageBox.Show("subject is deleted!!");
                LoadSubjects();

            }
            else
            {
                MessageBox.Show("to delete. You should select a subject");
            }
        }

        private void btn_appointment_insert_click(object sender, RoutedEventArgs e)
        {
            Appointments appointment = new Appointments();
            appointment.AppointmentHour = Int32.Parse(textbox_appointmentHour.Text);
            appointment.AppointmentSubjectId = Int32.Parse(textbox_appointmentSubjectId.Text);
            appointment.AppointmentDate = datePicker_appointmentDate.SelectedDate.Value;
            appointment.DoctorId = Int32.Parse(textbox_appointmentDoctorID.Text);
            appointment.PatientId = Int32.Parse(textbox_appointmentPatientID.Text);
            appointment.DoctorNotes = textbox_appointmentDoctorNotes.Text;

            HospitalDB db = new HospitalDB();
            db.Appointments.Add(appointment);

            db.SaveChanges();
            MessageBox.Show("Appointment is saved...");
            textbox_appointmentHour.Text = "";
            textbox_appointmentSubjectId.Text = "";
            textbox_appointmentDoctorID.Text = "";
            textbox_appointmentPatientID.Text = "";
            textbox_appointmentDoctorNotes.Text = "";
            datePicker_appointmentDate.SelectedDate = DateTime.Now;
            LoadAppointments();
        }

        private void btn_appointment_update_click(object sender, RoutedEventArgs e)
        {
            Appointments appointment = grid_appointments.SelectedItem as Appointments;
            if (appointment != null)
            {
                HospitalDB db = new HospitalDB();
                var appointmentnew = db.Appointments.Find(appointment.Id);
                appointmentnew.AppointmentHour = Int32.Parse(textbox_appointmentHour.Text);
                appointmentnew.AppointmentSubjectId = Int32.Parse(textbox_appointmentSubjectId.Text);
                appointmentnew.AppointmentDate = datePicker_appointmentDate.SelectedDate.Value;
                appointmentnew.DoctorId = Int32.Parse(textbox_appointmentDoctorID.Text);
                appointmentnew.PatientId = Int32.Parse(textbox_appointmentPatientID.Text);
                appointmentnew.DoctorNotes = textbox_appointmentDoctorNotes.Text;
                db.SaveChanges();
                LoadAppointments();
                MessageBox.Show("Updated.");
            }
            else
            {
                MessageBox.Show("to update. You should select a doctor.");
            }
        }

        private void btn_appointment_delete_Click(object sender, RoutedEventArgs e)
        {
            Appointments appointment = grid_appointments.SelectedItem as Appointments;
            if (appointment != null)
            {
                HospitalDB db = new HospitalDB();
                db.Appointments.Remove(appointment);
                db.SaveChanges();
                MessageBox.Show("appointment is deleted!!");
                LoadAppointments();

            }
            else
            {
                MessageBox.Show("to delete. You should select a appointment");
            }
        }

        private void grid_appointments_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Appointments appointment = grid_appointments.SelectedItem as Appointments;
            if (appointment != null)
            {
                textbox_appointmentDoctorID.Text = appointment.DoctorId.ToString();
                textbox_appointmentPatientID.Text = appointment.PatientId.ToString();
                datePicker_appointmentDate.SelectedDate = appointment.AppointmentDate;
                textbox_appointmentHour.Text = appointment.AppointmentHour.ToString();
                textbox_appointmentSubjectId.Text = appointment.AppointmentSubjectId.ToString();
                textbox_appointmentDoctorNotes.Text = appointment.DoctorNotes;
            }
        }

        private void grid_subjects_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Subjects subject = grid_subjects.SelectedItem as Subjects;
            if (subject != null)
            {
                textbox_subjectName.Text = subject.Name;
            }
        }
    }
}
