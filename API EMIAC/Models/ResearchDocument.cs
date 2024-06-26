using System;
using System.Collections.Generic;

namespace API_EMIAC.Models;

public partial class ResearchDocument
{
    public int? IdResearchDocument { get; set; }

    public int? IdAppointment { get; set; }

    public string ContentResearchRtf { get; set; } = null!;

    public byte[]? Attachment { get; set; }
}