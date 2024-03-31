using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب اختيار  المحافظه")]
        public string city { get; set; }
    }
}
