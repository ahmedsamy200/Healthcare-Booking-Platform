using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class AppointmentsViewModel
    {
        public int Id { get; set; }
        public int? doctorID { get; set; }
        public int? userID { get; set; }
        public string dayAr { get; set; }
        public DateTime? from { get; set; }
        public bool status { get; set; }
        public string name { get; set; }  
        public string userPhone { get; set; }
        public string doctorName { get; set; }
        public string address { get; set; }
    }
}
