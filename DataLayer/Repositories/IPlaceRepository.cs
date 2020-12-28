using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPlaceRepository:IDisposable
    {
        IEnumerable<Place> GetAllPlaces();
        Place GetPlaceById(int placeId);
        bool InsertPlace(Place place);
        bool UpdatePlace(Place place);
        bool DeletePlace(Place place);
        bool DeletePlace(int placeId);
        void Save();

        IEnumerable<Place> TopPlaces(int take = 8);
    }
}
