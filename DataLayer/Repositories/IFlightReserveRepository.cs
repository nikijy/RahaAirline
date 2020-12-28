using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IFlightReserveRepository:IDisposable
    {
        IEnumerable<FlightReserve> GetAllFlightReserves();
        FlightReserve GetFlightReserveById(int flightReserveId);
        bool InsertFlightReserve(FlightReserve flightReserve);
        bool UpdateFlightReserve(FlightReserve flightReserve);
        bool DeleteFlightReserve(FlightReserve flightReserve);
        bool DeleteFlightReserve(int flightReserveId);
        void Save();

      
    }
}
