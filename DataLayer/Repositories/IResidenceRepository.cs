using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IResidenceRepository:IDisposable
    {
        IEnumerable<Residence> GetAllResidences();
        Residence GetResidenceById(int residenceId);
        bool InsertResidence(Residence residence);
        bool UpdateResidence(Residence residence);
        bool DeleteResidence(Residence residence);
        bool DeleteResidence(int residenceId);
        void Save();


        IEnumerable<Residence> GetAvailableResidences();
        IEnumerable<Residence> TopResidences(int take = 4);
        int ResidenceCounts();
        IEnumerable<Residence> ResidencePagging();
        IEnumerable<Residence> SearchResidence(string search);
    }
}
