using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDoctorService
    {
        Task<Doctor> Login(Doctor doctor);
        Task<bool> AddDoctor(Doctor doctor);
        Task<bool> UpdateDoctor(Doctor doctor);
        Task<bool> UpdateDetails(Doctor doctor);
        Task<bool> ChangePassword(Doctor doctor);
        Task<bool> DeleteDoctor(int id);
        Task<IEnumerable<Doctor>> GetDoctorByName(string name);
        Task<bool> IsExist(Doctor doctor);
        Task<Doctor> GetDoctorById(int id);
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<IEnumerable<Doctor>> FilterDoctors(string specialization, int maxPrice, int minPrice,string gender , string city , string doctorName);
    }
}
