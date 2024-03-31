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
    public class SpecializationService : ISpecializationService
    {
        private readonly IRepository<Specialization> _repository;
        public SpecializationService(IRepository<Specialization> repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddSpecialization(Specialization specialization)
        {
            try
            {
                specialization.Id = 0;
                var result = await _repository.Add(specialization);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteSpecialization(int id)
        {
            try
            {
                if (_repository.GetById(id).Result == null)
                {
                    return false;
                }
                await _repository.Delete(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Specialization>> GetAllSpecializations()
        {
            try
            {

                return await _repository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Specialization> GetSpecializationById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _repository.GetById(id);
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

        public async Task<IEnumerable<Specialization>> GetSpecializationByName(string name)
        {
            try
            {
                if (name != null)
                {
                    var specializations = _repository.GetAll().Result.Where(x=>x.name.Contains(name));
                    return specializations;
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

        public async Task<bool> IsExist(Specialization specialization)
        {
            try
            {
                if (specialization.name != null)
                {
                    var result = _repository.GetAll().Result.FirstOrDefault(x => x.name == specialization.name);
                    if (result != null)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSpecialization(Specialization specialization, int id)
        {
            try
            {

                await _repository.Update(specialization);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
