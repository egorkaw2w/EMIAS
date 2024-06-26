using System;
using System.Collections.Generic;

namespace API_EMIAC.Models;

public partial class AnalysDocument
{
    public int? IdAnalysDocument { get; set; }

    public int? IdAppointment { get; set; }

    public string ContentAnalysRtf { get; set; } = null!;
}