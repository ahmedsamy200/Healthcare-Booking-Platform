using Domain;
using Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointments> _repository;
        private readonly ApplicationDbContext _dbContext;

        public AppointmentService(IRepository<Appointments> repository, ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<bool> AddAppointments(Appointments appointment)
        {
            try
            {
                appointment.Id = 0;
                appointment.Doctor = null;
                appointment.User = null;
                var result = await _repository.Add(appointment);
                if (result)
                {
                    return true;

                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> AvailableAppointment(Appointments appointment)
        {
            try
            {
                var result = _repository.GetAll().Result.FirstOrDefault(x=>x.doctorID == appointment.doctorID && x.dayAr == appointment.dayAr && x.from == appointment.from);
                if (result == null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            try
            {
                if (await _repository.Delete(id))
                {
                    return true;
                }
               
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Appointments>> GetAppointments(int doctorID)
        {
            try
            {
                if (doctorID > 0)
                {
                    var result = _dbContext.Appointments.Include(x => x.User).Where(x => x.doctorID == doctorID && x.User.IsActive == true).OrderBy(x => x.Id).ToList();
                    //var result = _repository.GetAll().Result.Where(x=>x.doctorID == doctorID).OrderBy(x=>x.Id).ToList();

                    if(result.Count > 0)
                    {
                        return result;
                    }
                    return null;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }    
        }

        public async Task<IEnumerable<Appointments>> GetAppointmentsByName(string name , int doctorID)
        {
            try
            {
                if (name != null)
                {
                    var appointments = _dbContext.Appointments.Include(x => x.User).Where(x => x.User.name.Contains(name) && x.doctorID == doctorID && x.User.IsActive == true).OrderBy(x => x.Id).ToList();
                    return appointments;
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

        public async Task<IEnumerable<Appointments>> GetUserAppointments(int userID)
        {
            try
            {
                if (userID > 0)
                {
                    var result = _dbContext.Appointments.Where(x => x.userID == userID && x.User.IsActive == true).Include(x => x.Doctor).OrderBy(x => x.Id).ToList();
                    //var result = _repository.GetAll().Result.Where(x=>x.doctorID == doctorID).OrderBy(x=>x.Id).ToList();

                    if (result.Count() > 0)
                    {
                        return result;
                    }
                    return null;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Appointments> UpdateStatus(int id , bool status)

        {
            try
            {
                if(id > 0)
                {
                    var result = _repository.GetAll().Result.FirstOrDefault(x => x.Id == id);
                    result.status = status;
                    await _repository.Update(result);
                    return result;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
