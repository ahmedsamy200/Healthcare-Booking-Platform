using Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User:BaseEntity
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? password { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }


    }
}
