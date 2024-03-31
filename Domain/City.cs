using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian;

namespace Domain
{
    public class City:BaseEntity
    {
        public string? city { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
