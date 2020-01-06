using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement
{
    public class Appointments
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int AppointmentHour { get; set; }
        public int AppointmentSubjectId{ get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string DoctorNotes { get; set; }
    }
}
