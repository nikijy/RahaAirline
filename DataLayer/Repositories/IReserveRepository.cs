using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IReserveRepository:IDisposable
    {
        IEnumerable<Reserve> GetAllReserves();
        Reserve GetReserveById(int reserveId);
        bool InsertReserve(Reserve reserve);
        bool UpdateReserve(Reserve reserve);
        bool DeleteReserve(Reserve reserve);
        bool DeleteReserve(int reserveId);
        void Save();
    }
}
