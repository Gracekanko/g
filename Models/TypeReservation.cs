using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class TypeReservation
{
    public string IdTypeReservation { get; set; } = null!;

    public string? NomType { get; set; }

    public decimal? PrixUnitaire { get; set; }

    public int? TauxPeriodique { get; set; }

    public virtual ICollection<Reservtion> Reservtions { get; set; } = new List<Reservtion>();

    public virtual ICollection<Vehicule> Vehicules { get; set; } = new List<Vehicule>();
}
