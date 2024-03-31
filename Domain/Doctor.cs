using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian;

namespace Domain
{
    public class Doctor:BaseEntity
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? photo { get; set; }
        public string? password { get; set; } 
        public string? address { get; set; }
        public string? subDescription { get; set; }
        public string? description { get; set; }
        public string? services { get; set; }
        public string? gender { get; set; }
        public double? views { get; set; }
        public decimal? price { get; set; }
        public int? cityID { get; set; }
        public int? specializationID { get; set; } 
        public bool IsActive { get; set; }


        public virtual Specialization Specialization { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}
