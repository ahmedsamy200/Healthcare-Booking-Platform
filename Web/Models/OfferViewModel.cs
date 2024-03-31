using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class OfferViewModel
    {
        public int Id { get; set; }
        public int doctorID { get; set; }
        public int appointmentID { get; set; }

        [Required(ErrorMessage = "يجب ادخال عنوان للعرض")]
        public string? title { get; set; }

        [Required(ErrorMessage = "يجب ادخال عنوان فرعي للعرض")]
        public string? subTitle { get; set; }

        [Required(ErrorMessage = "يجب ادخال وصف للعرض")]

        public string? description { get; set; }

        [Required(ErrorMessage = "يجب ادخال سعر للعرض")]
        [Range(0, 10000 , ErrorMessage = "يجب ادخال سعر بين 0 - 10000")]
        public decimal? price { get; set; }

        [Required(ErrorMessage = "يجب اتخيار صوره للعرض")]
        public IFormFile mainPhotoUploaded { get; set; }

        public string? mainPhoto { get; set; }

        [Required(ErrorMessage = "يجب اتخيار صور للعرض")]
        public List<IFormFile> offerPhotos { get; set; }


        public string? doctorName { get; set; }
        public string? doctorImage { get; set; }
        public string? address { get; set; }


        public string? city { get; set; }



    }
}
