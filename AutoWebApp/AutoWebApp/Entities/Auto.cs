using System;
using System.Collections.Generic;

namespace AutoWebApp.Entities;

public partial class Auto
{
    public Guid Autoid { get; set; }

    public string Modell { get; set; } = null!;

    public string Marke { get; set; } = null!;

    public DateOnly? Baujahr { get; set; }

    public int? Preis { get; set; }

    public Guid? Kategorienid { get; set; }
}
