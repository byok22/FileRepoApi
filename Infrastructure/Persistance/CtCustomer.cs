using System;
using System.Collections.Generic;

namespace TodoApi.Infrastructure.Persistance;

public partial class CtCustomer
{
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int PkCustomer { get; set; }

    public string CustomerName { get; set; } = null!;

    public int? FkmesCustomerId { get; set; }

    public int? FkbuildingId { get; set; }

    public int? FkdivisionId { get; set; }

    public string? Server { get; set; }

    public string? ServerReporting { get; set; }

    public int? FkserverMesid { get; set; }

    public bool Available { get; set; }
}
