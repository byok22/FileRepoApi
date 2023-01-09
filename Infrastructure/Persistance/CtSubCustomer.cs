using System;
using System.Collections.Generic;

namespace TodoApi.Infrastructure.Persistance;

public partial class CtSubCustomer
{
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int PksubCustomerId { get; set; }

    public string SubCustomerName { get; set; } = null!;

    public int FkcustomerId { get; set; }
}
