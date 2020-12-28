using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IFlightClassRepository:IDisposable
    {
        IEnumerable<FlightClass> GetAllFlightClasses();
        FlightClass GetFlightClassById(int flightClassId);
        bool InsertFlightClass(FlightClass flightClass);
        bool UpdateFlightClass(FlightClass flightClass);
        bool DeleteFlightClass(FlightClass flightClass);
        bool DeleteFlightClass(int flightClassId);
        void Save();
    }
}
