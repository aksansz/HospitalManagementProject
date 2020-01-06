using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement
{
    public class Patients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string DoctorNotes { get; set; }

    }
}
