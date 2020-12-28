using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace DataLayer
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(150)]
    //    [Remote("IsUserExists", "Accounts", ErrorMessage = "این نام کاربری در سایت موجود است !!! ")]
        public string UserName { get; set; }

    
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(150)]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
     //   [Remote("IsUserExist", "Accounts", ErrorMessage = "این ایمیل در سایت موجود است !!! ")]

        public string Email { get; set; }

        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [StringLength(11, ErrorMessage = "شماره همراه معتبر نیست")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "شماره همراه معتبر نیست")]
        public string Mobile { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(20, ErrorMessage = "رمز عبور باید از 20 کاراکتر کمتر باشد")]
        [MinLength(4, ErrorMessage = "رمز عبور باید از 4 کاراکتر بیشتر باشد ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "رمز عبور و رمز عبور تاییدی با یکدیگر مطابق نیستند")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [StringLength(10,ErrorMessage = "کد ملی 10 رقمی را وارد کنید")]
        public string NationalCode { get; set; }
      

        //public virtual List<Reserve> Reserves { get; set; }
        //public virtual List<FlightReserve> FlightReserves { get; set; }

        public User()
        {

        }
    }
}
