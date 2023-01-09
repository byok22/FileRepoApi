using System;
using System.Collections.Generic;

namespace TodoApi.Infrastructure.Persistance;

public partial class ScUser
{
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int PkuserId { get; set; }

    public int? FkmesUserId { get; set; }

    public int? EmployeeNumer { get; set; }

    public string? Ntuser { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? SecondLastName { get; set; }

    public string? Email { get; set; }

    public int? FkroleId { get; set; }

    public bool? Available { get; set; }
}
