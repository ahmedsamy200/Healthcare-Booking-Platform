using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب ادخال الاسم ")]
        public string? name { get; set; }

        [Required(ErrorMessage = "يجب ادخال البريد الالكتروني ")]
        public string? email { get; set; }

        [Required(ErrorMessage = "يجب ادخال رقم الهاتف ")]
        public string? phone { get; set; }

        [Required(ErrorMessage = "يجب ادخال كلمه المرور ")]
        public string? password { get; set; }

        [Required(ErrorMessage = "يجب تاكيد كلمه المرور ")]
        [Compare("password", ErrorMessage = "كلمه المرور غير متطابقه")]
        public string confirmPassword { get; set; }

        public bool IsActive { get; set; }

    }
}
