using System.ComponentModel.DataAnnotations;
namespace Web.Models
{
    public class DoctorAppointmentsViewModel
    {

        public int? doctorID { get; set; }
        public string? dayAr { get; set; }
        public string? dayEn { get; set; }
        public string? doctorName { get; set; }
        public string? address { get; set; }
        public int? duration { get; set; }
        public int? order { get; set; }
        public string? from { get; set; }
        public string? to { get; set; }
    }
}
