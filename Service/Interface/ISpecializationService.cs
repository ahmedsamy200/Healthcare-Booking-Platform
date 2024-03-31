using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ISpecializationService
    {
        Task<bool> AddSpecialization(Specialization specialization);
        Task<bool> UpdateSpecialization(Specialization specialization, int id);
        Task<bool> DeleteSpecialization(int id);
        Task<IEnumerable<Specialization>> GetSpecializationByName(string name);
        Task<bool> IsExist(Specialization specialization);
        Task<Specialization> GetSpecializationById(int id);
        Task<IEnumerable<Specialization>> GetAllSpecializations();
    }
}
