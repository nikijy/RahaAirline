using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IFlightRepository:IDisposable
    {
        IEnumerable<Flight> GetAllFlights();
        Flight GetFlightById(int flightId);
        bool InsertFlight(Flight flight);
        bool UpdateFlight(Flight flight);
        bool DeleteFlight(Flight flight);
        bool DeleteFlight(int flightId);
        void Save();

        //IEnumerable<Flight> GetAvailableFlights();
        IEnumerable<Flight> SearchFlights(string from, string destination, string departure);
    }
}
