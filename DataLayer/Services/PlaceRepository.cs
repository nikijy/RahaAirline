using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PlaceRepository:IPlaceRepository
    {

        private RahaAirlineContext db;

        public PlaceRepository(RahaAirlineContext context)
        {
            db = context;
        }
        public IEnumerable<Place> GetAllPlaces()
        {
            return db.Places;
        }

        public Place GetPlaceById(int placeId)
        {
            return db.Places.Find(placeId);
        }

        public bool InsertPlace(Place place)
        {
            try
            {
                db.Places.Add(place);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdatePlace(Place place)
        {
            try
            {
                db.Entry(place).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePlace(Place place)
        {
            try
            {
                db.Entry(place).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePlace(int placeId)
        {
            try
            {
                var place = GetPlaceById(placeId);
                DeletePlace(place);
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

        public IEnumerable<Place> TopPlaces(int take = 8)
        {
            return db.Places.OrderByDescending(P => P.Visit).Take(take);
        }
    }
}
