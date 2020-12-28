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
    public class Residence
    {
        [Key]
        public int ResidenceID { get; set; }
        [Display(Name = "نوع اقامتگاه")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        public int ResidenceTypeID { get; set; }
        [Display(Name = " مکان")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(300)]
        public string Location { get; set; }
        [Display(Name = "تصویر")]
        public string Image { get; set; }
        [Display(Name = "تاریخ و ساعت ورود")]
        public string CheckIn { get; set; }
        [Display(Name = "تاریخ و ساعت خروج")]
        public string CheckOut { get; set; }
        [Display(Name = "تعداد مسافران")]
        public int? Passengers { get; set; }
        [Display(Name = "تعداد اتاق")]
        public int? RoomNumber { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        public int Price { get; set; }
        [Display(Name = "بازدید")]
        public int Visit { get; set; }
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
        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "کلمات کلیدی")]
        public string Tag { get; set; }

        public bool? IsAvailable { get; set; } = true;

        public virtual List<Reserve> Reserves { get; set; }
        public virtual ResidenceType ResidenceType { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public Residence()
        {

        }
    }
}
