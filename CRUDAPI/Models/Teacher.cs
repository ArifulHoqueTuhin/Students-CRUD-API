using System;
using System.Collections.Generic;

namespace CRUDAPI.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public int Salary { get; set; }
}
