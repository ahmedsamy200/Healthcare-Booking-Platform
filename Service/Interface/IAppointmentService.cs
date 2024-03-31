using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service.Interface
{
    public interface IAppointmentService
    {
        Task<bool> AddAppointments(Appointments appointments);

        Task<IEnumerable<Appointments>> GetAppointments(int doctorID);
        Task<IEnumerable<Appointments>> GetUserAppointments(int userID);
        Task<IEnumerable<Appointments>> GetAppointmentsByName(string name, int doctorID);
        Task<Appointments> UpdateStatus(int id, bool status);
        Task<bool> AvailableAppointment(Appointments appointment);
        Task<bool> DeleteAppointment(int id);

    }
}
