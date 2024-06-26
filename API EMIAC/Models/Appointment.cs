using System;
using System.Collections.Generic;

namespace API_EMIAC.Models;

public partial class Appointment
{
    public int? IdAppointment { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly AppoitmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public int? StatusikId { get; set; }
}