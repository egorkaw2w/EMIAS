using System;
using System.Collections.Generic;

namespace API_EMIAC.Models;

public partial class Direction
{
    public int? IdDirections { get; set; }

    public int? SpecialityId { get; set; }

    public int? PatientId { get; set; }
}