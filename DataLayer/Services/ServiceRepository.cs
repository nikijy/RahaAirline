using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class ServiceRepository : IServiceRepository
    {

        private RahaAirlineContext db;

        public ServiceRepository(RahaAirlineContext context)
        {
            db = context;
        }
        public IEnumerable<Service> GetAllServices()
        {
            return db.Services;
        }

        public Service GetServiceById(int serviceId)
        {
            return db.Services.Find(serviceId);
        }

        public bool InsertService(Service service)
        {
            try
            {
                db.Services.Add(service);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateService(Service service)
        {
            try
            {
                db.Entry(service).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
      
        public bool DeleteService(Service service)
        {
            try
            {
                db.Entry(service).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteService(int serviceId)
        {
            try
            {
                var service = GetServiceById(serviceId);
                DeleteService(serviceId);
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

        public IEnumerable<Service> TopServices(int take = 3)
        {
            return db.Services.OrderByDescending(s => s.ServiceID).Take(take);
        }
    }
}
