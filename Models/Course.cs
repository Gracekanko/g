using System;
using System.Collections.Generic;

namespace GogoDriverWeb.Models;

public partial class Course
{
    public string IdCourse { get; set; } = null!;

    public string IdVehicule { get; set; } = null!;

    public string IdReservation { get; set; } = null!;

    public DateTime? DateCourse { get; set; }

    public DateTime? HeureCourse { get; set; }

    public int? EtatCourse { get; set; }

    public bool? Destination { get; set; }

    public bool? Position { get; set; }

    public virtual Reservtion IdReservationNavigation { get; set; } = null!;

    public virtual Vehicule IdVehiculeNavigation { get; set; } = null!;
}
