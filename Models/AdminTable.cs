using System;
using System.Collections.Generic;

namespace A2test.Models;

public partial class AdminTable
{
    public int? Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string EnterPassword { get; set; } = null!;
}
