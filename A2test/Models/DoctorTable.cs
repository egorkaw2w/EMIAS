using System;
using System.Collections.Generic;

namespace A2test.Models;

public partial class DoctorTable
{
    public int? Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string EnterPassword { get; set; } = null!;

    public string WorkAddress { get; set; } = null!;

    public int SpecialityId { get; set; }

    public virtual SpecialitiesTable Speciality { get; set; } = null!;
}
