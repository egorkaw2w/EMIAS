using System;

namespace C_mainproject2
{
    public class Appointment
    {
        public string PatientName { get; set; }
        public DateTime AppointmentTime { get; set; }
        public bool IsCompleted { get; set; }

        public bool IsPast => DateTime.Now > AppointmentTime;
    }
}
