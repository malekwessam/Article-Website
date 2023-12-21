using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArticleProject.ViewModel
{
    public class AuthorView
    {

        [Required]
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "الاسم الكامل")]
        public string FullName { get; set; }
        [Display(Name = "السيرة الذاتية")]
        public string Bio { get; set; }
        [Display(Name = "الصورة")]
        public IFormFile BathImage { get; set; }
        [Required]
        [Display(Name = "معرف المستخدم")]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }
        [Display(Name = "فيسبوك")]
        public string Facebook { get; set; }
        [Display(Name = "الانستجرام")]
        public string Twitter { get; set; }
        [Display(Name = "التويتر")]
        public string Instagram { get; set; }
    }
}
