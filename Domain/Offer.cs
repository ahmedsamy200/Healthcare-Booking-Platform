using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian;

namespace Domain
{
    public class Offer:BaseEntity
    {
        public int? doctorID { get; set; }
        public string? title { get; set; }
        public string? subTitle { get; set; }
        public string? description { get; set; }

        public decimal? price { get; set; }

        public string? mainPhoto { get; set; }

        public virtual Doctor Doctor { get; set; }

    }
}
