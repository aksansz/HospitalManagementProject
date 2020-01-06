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
    }
}
