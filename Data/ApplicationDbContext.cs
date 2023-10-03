using GogoDriverWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GogoDriverWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<ModePaiement> ModePaiements { get; set; }

        public virtual DbSet<Paiement> Paiements { get; set; }

        public virtual DbSet<Plainte> Plaintes { get; set; }

        public virtual DbSet<Reservtion> Reservtions { get; set; }

        public virtual DbSet<So> Sos { get; set; }

        public virtual DbSet<TypeReservation> TypeReservations { get; set; }

        public virtual DbSet<TypeVehicule> TypeVehicules { get; set; }

        public virtual DbSet<Vehicule> Vehicules { get; set; }


    }
}