using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ContactUsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال الاسم ")]
        public string? firstName { get; set; }

        [Required(ErrorMessage = "يجب ادخال الاسم التاني  ")]
        public string? lastName { get; set; }

        [Required(ErrorMessage = "يجب ادخال البريد الالكتروني ")]
        public string? email { get; set; }

        [Required(ErrorMessage = "يجب ادخال رقم هاتف صحيح ")]
        [RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "يجب ادخال رقم هاتف صحيح")]

        public string? phone { get; set; }

        [Required(ErrorMessage = "يجب ادخال الرساله ")]
        public string? massage { get; set; }
    }
}
