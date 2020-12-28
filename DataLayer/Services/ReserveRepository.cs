using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ReserveRepository:IReserveRepository
    {
        private RahaAirlineContext db;

        public ReserveRepository(RahaAirlineContext context)
        {
            db = context;
        }

        public IEnumerable<Reserve> GetAllReserves()
        {
            return db.Reserves;
        }

        public Reserve GetReserveById(int reserveId)
        {
            return db.Reserves.Find(reserveId);
        }

        public bool InsertReserve(Reserve reserve)
        {
            try
            {
                db.Reserves.Add(reserve);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateReserve(Reserve reserve)
        {
            try
            {
                db.Entry(reserve).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteReserve(Reserve reserve)
        {
            try
            {
                db.Entry(reserve).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteReserve(int reserveId)
        {
            try
            {
                var reserve = GetReserveById(reserveId);
                DeleteReserve(reserve);
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
