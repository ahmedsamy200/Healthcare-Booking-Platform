using Domain;
using Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ClinicPhotosService : IClinicPhotosService
    {
        private readonly IRepository<ClinicPhotos> _repository;
        private readonly ApplicationDbContext _dbContext;

        public ClinicPhotosService(IRepository<ClinicPhotos> repository, ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<bool> AddClinicPhotos(ClinicPhotos clinicPhotos)
        {
            try
            {
                var result = await _repository.Add(clinicPhotos);
                if (result)
                {
                    return true;

                }
                return false;

                //clinicPhotos.Doctor = null;
                //clinicPhotos.Id = 0;
                //var result = await _repository.Add(clinicPhotos);
                //return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

   

        public async Task<IEnumerable<ClinicPhotos>> DeleteClinicPhotos(int id)
        {
            try
            {
                var clinicPhotos = _repository.GetAll().Result.Where(x => x.doctorID == id);
                if (clinicPhotos == null)
                {
                    return null;
                }
                foreach (var item in clinicPhotos)
                {
                    await _repository.Delete(item.Id);

                }
                return clinicPhotos;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<ClinicPhotos>> GetClinicPhotos(int doctorID)
        {
            try
            {
                if (doctorID > 0)
                {
                    var allPhotos =await _repository.GetAll();
                    var result = allPhotos.Where(x=>x.doctorID == doctorID);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
