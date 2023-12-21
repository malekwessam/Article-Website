using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticleProject.Core
{
    public class Author
    {
        [Required]
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Required]
        [Display(Name ="الاسم الكامل")]
        public string FullName { get; set; }
        [Display(Name = "السيرة الذاتية")]
        public string? Bio { get; set; }
        [Display(Name = "الصورة")]
        public string? BathImage { get; set; }
        [Required]
        [Display(Name = "معرف المستخدم")]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }
        [Display(Name = "فيسبوك")]
        public string? Facebook { get; set; }
        [Display(Name = "الانستجرام")]
        public string? Twitter { get; set; }
        [Display(Name = "التويتر")]
        public string? Instagram { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
