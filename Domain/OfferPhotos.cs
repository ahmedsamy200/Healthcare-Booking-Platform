using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian;

namespace Domain
{
    public class OfferPhotos:BaseEntity
    {
        public int? offerID { get; set; }
        public string? image { get; set; }

        public virtual Offer Offer { get; set; }

    }
}
