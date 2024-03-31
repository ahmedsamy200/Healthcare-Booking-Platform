using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian;

namespace Domain
{
    public class Review:BaseEntity
    {
        [ForeignKey("doctorID")]
        public int? doctorID { get; set; }

        [ForeignKey("userID")]
        public int? userID { get; set; }
        public string? comment { get; set; }
        public float? rate { get; set; }
        public DateTime? date { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual User User { get; set; }

    }
}
