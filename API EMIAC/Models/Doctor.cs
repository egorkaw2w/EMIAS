using System;
using System.Collections.Generic;

namespace API_EMIAC.Models;

public partial class Doctor
{
    public int? IdDoctor { get; set; }

    public string DoctorSurname { get; set; } = null!;

    public string DoctorName { get; set; } = null!;

    public string? DoctorMiddleName { get; set; }

    public int? SpecialityId { get; set; }
    public string DoctorEnterLogin { get; set; } = null!;

    public string DoctorEnterPassword { get; set; } = null!;

    public string WorkAddress { get; set; } = null!;
}