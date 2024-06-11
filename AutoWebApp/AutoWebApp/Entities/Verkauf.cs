using System;
using System.Collections.Generic;

namespace AutoWebApp.Entities;

public partial class Verkauf
{
    public Guid Verkaufsid { get; set; }

    public DateOnly? Verkaufsdatum { get; set; }

    public Guid? Autoid { get; set; }

    public Guid? Kundenid { get; set; }
}
