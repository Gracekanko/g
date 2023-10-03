using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class Reservtion
{
    public string IdReservation { get; set; } = null!;

    public string IdPersonne { get; set; } = null!;

    public string IdTypeReservation { get; set; } = null!;

    public DateTime? DateReservation { get; set; }

    public DateTime? HeureDebut { get; set; }

    public DateTime? HeureFin { get; set; }

    public bool? Position { get; set; }

    public int? NbrePassages { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Personne IdPersonneNavigation { get; set; } = null!;

    public virtual TypeReservation IdTypeReservationNavigation { get; set; } = null!;

    public virtual ICollection<Paiement> IdPaiements { get; set; } = new List<Paiement>();
}
