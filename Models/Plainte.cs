using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class Plainte
{
    public string PlainteId { get; set; } = null!;

    public string PersonneId { get; set; } = null!;

    public string? LibellePlainte { get; set; }

    public DateTime? DatePlainte { get; set; }

    public virtual Personne PersonneIdNavigation { get; set; } = null!;
}
