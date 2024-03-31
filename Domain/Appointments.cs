using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian;

namespace Domain
{
    public class Appointments:BaseEntity
    {
        [ForeignKey("doctorID")]
        public int? doctorID { get; set; }

        [ForeignKey("userID")]
        public int? userID { get; set; }
        public string? dayAr { get; set; }

        public DateTime? from { get; set; }

        public bool status { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual User User { get; set; }

    }
}
