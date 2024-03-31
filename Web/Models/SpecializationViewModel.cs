using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class SpecializationViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم التخصص")]
        public string? name { get; set; }

    }
}
