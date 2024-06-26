using System;
using System.Collections.Generic;

namespace A2test.Models;

public partial class ResearchDocumentTable
{
    public int? Id { get; set; }

    public string Rtf { get; set; } = null!;

    public byte[] Attachment { get; set; } = null!;

    public int AppointmentId { get; set; }

    public virtual AppointmentsTable Appointment { get; set; } = null!;
}
