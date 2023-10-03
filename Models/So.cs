using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class So
{
    public string IdSos { get; set; } = null!;

    public string IdPersonne { get; set; } = null!;

    public int? Localisation { get; set; }

    public string? Description { get; set; }

    public virtual Personne IdPersonneNavigation { get; set; } = null!;
}
