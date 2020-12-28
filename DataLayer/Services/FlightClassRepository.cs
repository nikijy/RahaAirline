using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FlightClassRepository:IFlightClassRepository
    {
        private RahaAirlineContext db;

        public FlightClassRepository(RahaAirlineContext context)
        {
            db = context;
        }

        public IEnumerable<FlightClass> GetAllFlightClasses()
        {
            return db.FlightClasses;
        }

        public FlightClass GetFlightClassById(int flightClassId)
        {
            return db.FlightClasses.Find(flightClassId);
        }

        public bool InsertFlightClass(FlightClass flightClass)
        {
            try
            {
                db.FlightClasses.Add(flightClass);
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool UpdateFlightClass(FlightClass flightClass)
        {
            try
            {
                db.Entry(flightClass).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteFlightClass(FlightClass flightClass)
        {
            try
            {
                db.Entry(flightClass).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteFlightClass(int flightClassId)
        {
            try
            {
                var flightClass = GetFlightClassById(flightClassId);
                DeleteFlightClass(flightClass);
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
