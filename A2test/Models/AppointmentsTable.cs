using System;
using System.Collections.Generic;

namespace A2test.Models;

public partial class AppointmentsTable
{
    public int? Id { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public long OmsId { get; set; }

    public int DoctorId { get; set; }

    public int StatusId { get; set; }

    public virtual DoctorTable Doctor { get; set; } = null!;

    public virtual PatientTable Oms { get; set; } = null!;

    public virtual StatusTable Status { get; set; } = null!;
}
