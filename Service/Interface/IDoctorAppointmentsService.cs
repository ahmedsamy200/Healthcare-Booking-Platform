using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service.Interface
{
    public interface IDoctorAppointmentsService
    {
        Task<bool> AddDoctorAppointments(DoctorAppointments appointments);
        Task<bool> UpdateDoctorAppointments(DoctorAppointments appointments);
        Task<bool> DeleteAppointment(int doctorID);

        Task<IEnumerable<DoctorAppointments>> GetDoctorAppointments(int doctorID);
        Task<DoctorAppointments> GetDoctorAppointmentByDayName(DoctorAppointments appointment);
        Task<DoctorAppointments> GetAppointmentByID(int id);
        Task<DoctorAppointments> GetAppointmentByDay(string day,int doctorID);
        Task<bool> AppointmentIsExist(DoctorAppointments appointment);
    }
}
