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
    public class DoctorAppointmentsService : IDoctorAppointmentsService
    {
        private readonly IRepository<DoctorAppointments> _repository;
        private readonly ApplicationDbContext _dbContext;

        public DoctorAppointmentsService(IRepository<DoctorAppointments> repository, ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<bool> AddDoctorAppointments(DoctorAppointments appointments)
        {
            try
            {
                appointments.Doctor = null;
                appointments.Id = 0;
                var result = await _repository.Add(appointments);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AppointmentIsExist(DoctorAppointments appointment)
        {
            try
            {
                if (appointment.dayEn != null)
                {
                    var appointments =await _repository.GetAll();
                    var result = appointments.Where(x => x.dayEn == appointment.dayEn && x.doctorID == appointment.doctorID).FirstOrDefault();
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

        public async Task<bool> DeleteAppointment(int doctorID)
        {
            try
            {
                var allAppointments = _repository.GetAll().Result.Where(x => x.doctorID == doctorID).ToList();
                if (allAppointments == null)
                {
                    return false;
                }
                foreach (var item in allAppointments)
                {
                    await _repository.Delete(item.Id);

                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<DoctorAppointments> GetAppointmentByDay(string day, int doctorID)
        {
            try
            {
                if (doctorID > 0)
                {
                    var appointment = _repository.GetAll().Result.FirstOrDefault(x => x.dayAr == day && x.doctorID == doctorID);
                    if (appointment != null)
                    {
                        return appointment;
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

        public async Task<DoctorAppointments> GetAppointmentByID(int id)
        {
            try
            {
                if (id > 0)
                {
                    var appointment = _dbContext.DoctorAppointments.Include(x=>x.Doctor).FirstOrDefault(x => x.Id == id);
                    //var appointment = _repository.GetAll().Result.FirstOrDefault(x => x.Id == id);
                    if (appointment != null)
                    {
                        return appointment;
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

        public async Task<DoctorAppointments> GetDoctorAppointmentByDayName(DoctorAppointments appointment)
        {
            try
            {
                if (appointment.dayEn != null && appointment.doctorID > 0)
                {
                    var appointments = await _repository.GetAll();
                    var result = appointments.Where(x => x.dayEn == appointment.dayEn && x.doctorID == appointment.doctorID).FirstOrDefault();
                    if (result != null)
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

        public async Task<IEnumerable<DoctorAppointments>> GetDoctorAppointments(int doctorID)
        {
            try
            {
                if (doctorID > 0)
                {
                    var allAppointments = _dbContext.DoctorAppointments.Include(x => x.Doctor).Where(x => x.doctorID == doctorID).OrderBy(x => x.order).ToList();

                    //var allAppointments =  _repository.GetAll().Result.Where(x => x.doctorID == doctorID).OrderBy(x => x.order).ToList();
                    if (allAppointments.Count > 0)
                    {
                       return allAppointments;
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

        public async Task<bool> UpdateDoctorAppointments(DoctorAppointments appointment)
        {
            try
            {

                var result =  _repository.GetAll().Result.Where(x=>x.dayEn == appointment.dayEn && x.doctorID == appointment.doctorID).FirstOrDefault();
                result.from = appointment.from;
                result.to = appointment.to;
                result.duration = appointment.duration;
                result.Doctor = null;
                await _repository.Update(result);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
