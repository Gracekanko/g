using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class Paiement
{
    public string IdPaiement { get; set; } = null!;

    public string IdModePaiement { get; set; } = null!;

    public string? MomtantPaiement { get; set; }

    public long? Telephone { get; set; }

    public DateTime? DatePaiement { get; set; }

    public string? EtatPaiement { get; set; }

    public string? Facturation { get; set; }

    public virtual ModePaiement IdModePaiementNavigation { get; set; } = null!;

    public virtual ICollection<Reservtion> IdReservations { get; set; } = new List<Reservtion>();
}
