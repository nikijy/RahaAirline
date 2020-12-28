using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IResidenceTypeRepository:IDisposable
    {
        IEnumerable<ResidenceType> GetAllResidenceTypes();
        ResidenceType GetResidenceTypeById(int residenceTypeId);
        bool InsertResidenceType(ResidenceType residenceType);
        bool UpdateResidenceType(ResidenceType residenceType);
        bool DeleteResidenceType(ResidenceType residenceType);
        bool DeleteResidenceType(int residenceTypeId);
        void Save();
    }
}
