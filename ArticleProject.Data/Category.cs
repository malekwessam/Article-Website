using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticleProject.Core
{
    public class Category
    {
        [Required]
        [Display(Name = "رقم التعريف")]
        public int id { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        [Display(Name = "اسم الصنف")]
        [MaxLength(50,ErrorMessage ="يجب الا يزيد الاسم عن 50 حرف")]
        [MinLength(3,ErrorMessage ="يجب الا يقل الاسم عن 3 احرف")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }

    }
}
