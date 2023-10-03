using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class Plainte
{
    public string IdPlainte { get; set; } = null!;

    public string IdPersonne { get; set; } = null!;

    public string? LibellePlainte { get; set; }

    public DateTime? DatePlainte { get; set; }

    public virtual Personne IdPersonneNavigation { get; set; } = null!;
}
