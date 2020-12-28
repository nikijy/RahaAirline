using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

//using System.Web.Mvc;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        public int CategoryID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }
        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        //[MaxLength(350)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }
        [Display(Name = "بازدید")]
        public int Visit { get; set; }
        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }
        [Display(Name = "تصویر")]
        public string Image { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "کلمات کلیدی")]
        public string Tag { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public Page()
        {

        }
    }
}
