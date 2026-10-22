using System;
using System.Collections.Generic;

namespace SGS.Infrastructure.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Grade { get; set; }

    public string Subject { get; set; } = null!;
}
