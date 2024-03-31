using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class DoctorAppointments:BaseEntity
    {
        public int? doctorID { get; set; }
        public string? dayAr { get; set; }
        public string? dayEn { get; set; }
        public int? duration { get; set; }

        public int? order { get; set; }

        public DateTime? from { get; set; }

        public DateTime? to { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
