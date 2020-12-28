using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FlightRepository : IFlightRepository
    {
        private RahaAirlineContext db;

        public FlightRepository(RahaAirlineContext context)
        {
            db = context;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return db.Flights;
        }

        public Flight GetFlightById(int flightId)
        {
            return db.Flights.Find(flightId);
        }

        public bool InsertFlight(Flight flight)
        {
            try
            {
                db.Flights.Add(flight);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateFlight(Flight flight)
        {
            try
            {
                db.Entry(flight).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteFlight(Flight flight)
        {
            try
            {
                db.Entry(flight).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteFlight(int flightId)
        {
            try
            {
                var flight = GetFlightById(flightId);
                DeleteFlight(flight);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

      
        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Flight> SearchFlights(string q,string a,string b)
        {
            return
                db.Flights.OrderBy(f => f.Departure)
                    .Where(
                    f =>
                        f.From.Contains(q) && f.Destination.Contains(a) && f.Departure.Contains(b));
        }
    }
}
