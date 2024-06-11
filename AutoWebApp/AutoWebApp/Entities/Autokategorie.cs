using System;
using System.Collections.Generic;

namespace AutoWebApp.Entities;

public partial class Autokategorie
{
    public Guid Kategorienid { get; set; }

    public string Bezeichnung { get; set; } = null!;
}
