using System;
using System.Collections.Generic;

namespace API_EMIAC.Models;

public partial class Patient
{
    public int? IdPatient { get; set; }

    public long Oms { get; set; }

    public string PatientSurname { get; set; } = null!;

    public string PatientName { get; set; } = null!;

    public string? PatientMiddleName { get; set; }

    public DateOnly PatientBirthDate { get; set; }

    public string PatientAddress { get; set; } = null!;

    public string? PatientLivingAddress { get; set; }

    public string? PatientPhoneNumber { get; set; }

    public string? PatientEmail { get; set; }

    public string? PatientNickName { get; set; }
}