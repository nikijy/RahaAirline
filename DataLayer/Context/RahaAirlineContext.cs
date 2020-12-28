using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class RahaAirlineContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightClass> FlightClasses { get; set; }
        public DbSet<FlightReserve> FlightReserves { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Residence> Residences { get; set; }
        public DbSet<ResidenceType> ResidenceTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }

       
    }
}
