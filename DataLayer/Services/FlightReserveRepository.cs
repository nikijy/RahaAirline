using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FlightReserveRepository : IFlightReserveRepository
    {
       
        private RahaAirlineContext db;

        public FlightReserveRepository(RahaAirlineContext context)
        {
            db = context;
          
        }

        public IEnumerable<FlightReserve> GetAllFlightReserves()
        {
            return db.FlightReserves;
        }

        public FlightReserve GetFlightReserveById(int flightReserveId)
        {
            return db.FlightReserves.Find(flightReserveId);
        }

        public bool InsertFlightReserve(FlightReserve flightReserve)
        {
            try
            {
                db.FlightReserves.Add(flightReserve);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateFlightReserve(FlightReserve flightReserve)
        {
            try
            {
                db.Entry(flightReserve).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeleteFlightReserve(int flightReserveId)
        {
            try
            {
                var flightReserve = GetFlightReserveById(flightReserveId);
                DeleteFlightReserve(flightReserve);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteFlightReserve(FlightReserve flightReserve)
        {
            try
            {
                db.Entry(flightReserve).State = EntityState.Deleted;
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

       
    }
}
