using System.ComponentModel.DataAnnotations;
using Domain;
namespace Web.Models
{
    public class DoctorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب ادخال الاسم ")]
        public string? name { get; set; }


        [Required(ErrorMessage = "يجب ادخال البريد الالكتروني ")]
        public string? email { get; set; }


        [Required(ErrorMessage = "يجب ادخال رقم الهاتف ")]
        public string? phone { get; set; }


        [Required(ErrorMessage = "يجب اختيار الصوره ")]
        public string? photo { get; set; }

        [Required(ErrorMessage = "يجب اختيار الصوره ")]
        public IFormFile doctorPhotoUploaded { get; set; }


        public IFormFile photoUploaded { get; set; }

        public List<IFormFile> clinicPhotos { get; set; }

        [Required(ErrorMessage = "يجب ادخال كلمه المرور ")]
        public string? password { get; set; }


        [Required(ErrorMessage = "يجب تاكيد كلمه المرور ")]
        [Compare("password", ErrorMessage = "كلمه المرور غير متطابقه")]
        public string confirmPassword { get; set; }


        [Required(ErrorMessage = "يجب ادخال عنوان العيادة ")]
        public string? address { get; set; }


        [Required(ErrorMessage = "يجب ادخال ملعومات عن الطبيب ")]
        public string? subDescription { get; set; }


        [Required(ErrorMessage = "يجب ادخال ملعومات عن الطبيب ")]
        public string? description { get; set; }


        [Required(ErrorMessage = "يجب ادخال خدمات العيادة ")]
        public string? services { get; set; }


        [Required(ErrorMessage = "يجب اختيار النوع ")]
        public string? gender { get; set; }

        public bool IsActive { get; set; }

        public double? views { get; set; }

        [Required(ErrorMessage = "يجب ادخال سعر الكشف")]
        [Range(0, 10000, ErrorMessage = "يجب ادخال سعر بين 0 - 10000")]
        public decimal? price { get; set; }
        public float? ratting { get; set; }


        [Required(ErrorMessage = "يجب اختيار  المحافظه")]
        public int? cityID { get; set; }

        [Required(ErrorMessage = "يجب اختيار التخصص  ")]
        public int? specializationID { get; set; }

        public string? specializationName { get; set; }
        public string? city { get; set; }

        public IEnumerable<DoctorAppointments> appointments { get; set; }
    }
}
