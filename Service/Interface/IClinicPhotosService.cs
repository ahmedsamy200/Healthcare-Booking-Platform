using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IClinicPhotosService
    {
        Task<bool> AddClinicPhotos(ClinicPhotos clinicPhotos);
        Task<IEnumerable<ClinicPhotos>> DeleteClinicPhotos(int doctorID);
        Task<IEnumerable<ClinicPhotos>> GetClinicPhotos(int doctorID);
    }
}
