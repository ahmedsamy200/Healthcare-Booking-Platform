using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _repository;
        private readonly ApplicationDbContext _dbContext;

        public DoctorService(IRepository<Doctor> repository , ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }
        public async Task<bool> AddDoctor(Doctor doctor)
        {
            try
            {
                doctor.Specialization = null;
                doctor.City = null;
                doctor.Id = 0;
                var result = await _repository.Add(doctor);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            try
            {
                var result =await _repository.GetById(id);
                if (result == null)
                {
                    return false;
                }
                result.IsActive = false;
                await _repository.Update(result);            
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            try
            {
                return  _dbContext.Doctor.Include(x => x.Specialization).Include(x=>x.City).Include(x=>x.Reviews).Where(x=> x.IsActive == true).ToList();
               // return await _repository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Doctor>> FilterDoctors(string specialization, int maxPrice, int minPrice, string gender, string city, string doctorName)
        {
            try
            {
                var result = _dbContext.Doctor.Include(x => x.Specialization).Include(x => x.City).Include(x => x.Reviews).Where(x => x.name.Contains(string.IsNullOrWhiteSpace(doctorName) ? "" : doctorName) && x.City.city.Contains(string.IsNullOrWhiteSpace(city) ? "" : city) && x.gender.Contains(string.IsNullOrWhiteSpace(gender) ? "" : gender) && x.Specialization.name.Contains(string.IsNullOrWhiteSpace(specialization) ? "" : specialization) && x.price >= minPrice && x.price <= maxPrice && x.IsActive == true).ToList();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            try
            {
                if (id > 0)
                {
                    return _dbContext.Doctor.Include(x => x.Specialization).Include(x => x.City).FirstOrDefault(x=>x.Id == id && x.IsActive == true);

                    //var result = await _repository.GetById(id);
                    //return result;
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

        public async Task<IEnumerable<Doctor>> GetDoctorByName(string name)
        {
            try
            {
                if (name != null)
                {
                    var doctors = _dbContext.Doctor.Include(x => x.City).Include(x=>x.Specialization).Where(x => x.City.city.Contains(name) || x.Specialization.name.Contains(name) || x.name.Contains(name) && x.IsActive == true).OrderBy(x => x.Id).ToList();

                   // var doctors = _repository.GetAll().Result.Where(x => x.name.Contains(name) && x.IsActive == true);
                    return doctors;
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

        public async Task<bool> IsExist(Doctor doctor)
        {
            try
            {
                if (doctor.email != null)
                {
                    var result = _repository.GetAll().Result.FirstOrDefault(x => x.email == doctor.email && x.Id != doctor.Id && x.IsActive == true);
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

        public async Task<Doctor> Login(Doctor doctor)
        {
            try
            {
                var doctors = await _repository.GetAll();
                var result = doctors.FirstOrDefault(x => x.email == doctor.email && x.password == doctor.password && x.IsActive == true);
                return result;
            }
            catch (Exception)
            {

                throw;
            }  
        }

        public async Task<bool> UpdateDetails(Doctor doctor)
        {
            try
            {
                var result =await _repository.GetById(doctor.Id);
                if (result != null)
                {
                    result.description = doctor.description;
                    result.cityID = doctor.cityID;
                    result.address = doctor.address;
                    result.price = doctor.price;
                    result.services = doctor.services;

                    await _repository.Update(result);
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<bool> UpdateDoctor(Doctor doctor)
        {
            try
            {
                var result =await _repository.GetById(doctor.Id);
                if (result != null)
                {
                    result.name = doctor.name;
                    if (doctor.cityID != null)
                    {
                        result.cityID = doctor.cityID;
                    }
                    if (doctor.photo != null)
                    {
                        result.photo = doctor.photo;
                    }
                    result.phone = doctor.phone;
                    result.specializationID = doctor.specializationID;
                    result.email = doctor.email;
                    result.gender = doctor.gender;
                    result.subDescription = doctor.subDescription;

                    await _repository.Update(result);
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> ChangePassword(Doctor doctor)
        {
            try
            {
                var result =await _repository.GetById(doctor.Id);
                if (result != null)
                {
                    result.password = doctor.password;
                    await _repository.Update(result);
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
