using System;
using System.Collections.Generic;

namespace API_EMIAC.Models;

public partial class Administrator
{
    public int? IdAdministrator { get; set; }

    public string AdminSurname { get; set; } = null!;

    public string AdminName { get; set; } = null!;

    public string? AdminMiddleName { get; set; }
    public string AdminEnterLogin { get; set; } = null!;

    public string AdminEnterPassword { get; set; } = null!;
}