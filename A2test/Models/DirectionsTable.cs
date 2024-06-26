using System;
using System.Collections.Generic;

namespace A2test.Models;

public partial class DirectionsTable
{
    public int? Id { get; set; }

    public int SpecialityId { get; set; }

    public long OmsId { get; set; }

    public virtual PatientTable Oms { get; set; } = null!;

    public virtual SpecialitiesTable Speciality { get; set; } = null!;
}
