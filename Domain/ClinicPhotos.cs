using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian;

namespace Domain
{
    public class ClinicPhotos:BaseEntity
    {
        public int? doctorID { get; set; }
        public string? image { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
