using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ResidenceRepository:IResidenceRepository
    {

        private RahaAirlineContext db;

        public ResidenceRepository(RahaAirlineContext context)
        {
            db = context;
        }
        public IEnumerable<Residence> GetAllResidences()
        {
            return db.Residences;
        }

        

        public Residence GetResidenceById(int residenceId)
        {
            return db.Residences.Find(residenceId);
        }

        public bool InsertResidence(Residence residence)
        {
            try
            {
                db.Residences.Add(residence);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateResidence(Residence residence)
        {
            try
            {
                db.Entry(residence).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteResidence(Residence residence)
        {
            try
            {
                db.Entry(residence).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteResidence(int residenceId)
        {
            try
            {
                var residence = GetResidenceById(residenceId);
                DeleteResidence(residence);
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

        public IEnumerable<Residence> GetAvailableResidences()
        {
            return db.Residences.Where(r => r.IsAvailable == true);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Residence> TopResidences(int take = 4)
        {
            return db.Residences.OrderByDescending(r => r.Visit).Take(take);
        }

        public int ResidenceCounts()
        {
            return db.Residences.Count();
        }

        public IEnumerable<Residence> ResidencePagging()
        {
            return db.Residences.OrderBy(r => r.ResidenceID);
        }

        public IEnumerable<Residence> SearchResidence(string search)
        {
            return
                db.Residences.Where(
                    p =>
                        p.ResidenceType.ResidenceKind.Contains(search) ||p.Location.Contains(search) || p.ShortDescription.Contains(search) || p.Tag.Contains(search) ||
                        p.Text.Contains(search)).Distinct();
        }
    }
}
