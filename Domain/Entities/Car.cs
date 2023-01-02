using System;
using System.Collections.Generic;

namespace TodoApi;

public partial class Car
{
    public int Id { get; set; }

    public string CarModel { get; set; } = null!;

    public string Brand { get; set; } = null!;
}
