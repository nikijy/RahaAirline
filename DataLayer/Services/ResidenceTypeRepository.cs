using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ResidenceTypeRepository:IResidenceTypeRepository
    {
        private RahaAirlineContext db;

        public ResidenceTypeRepository(RahaAirlineContext context)
        {
            db = context;
        }
        public IEnumerable<ResidenceType> GetAllResidenceTypes()
        {
            return db.ResidenceTypes;
        }

        public ResidenceType GetResidenceTypeById(int residenceTypeId)
        {
            return db.ResidenceTypes.Find(residenceTypeId);
        }

        public bool InsertResidenceType(ResidenceType residenceType)
        {
            try
            {
                db.ResidenceTypes.Add(residenceType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateResidenceType(ResidenceType residenceType)
        {
            try
            {
                db.Entry(residenceType).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteResidenceType(ResidenceType residenceType)
        {
            try
            {
                db.Entry(residenceType).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteResidenceType(int residenceTypeId)
        {
            try
            {
                var residenceType = GetResidenceTypeById(residenceTypeId);
                DeleteResidenceType(residenceType);
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
