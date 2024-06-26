using System;
using System.Collections.Generic;

namespace API_EMIAC.Models;

public partial class AppointmentDocument
{
    public int? IdAppointmentDocument { get; set; }

    public int? IdAppointment { get; set; }

    public string ContentAppointmentRtf { get; set; } = null!;
}