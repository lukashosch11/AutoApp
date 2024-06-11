using System;
using System.Collections.Generic;

namespace AutoWebApp.Entities;

public partial class Kunde
{
    public Guid Kundenid { get; set; }

    public string Vorname { get; set; } = null!;

    public string Nachname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Wohnort { get; set; } = null!;

    public string Straße { get; set; } = null!;

    public int? Postleitzahl { get; set; }
}
