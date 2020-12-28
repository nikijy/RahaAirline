using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IServiceRepository:IDisposable
    {
        IEnumerable<Service> GetAllServices();
        Service GetServiceById(int serviceId);
        bool InsertService(Service service);
        bool UpdateService(Service service);
        bool DeleteService(Service service);
        bool DeleteService(int serviceId);
        void Save();

        IEnumerable<Service> TopServices(int take = 3);
    }
}
