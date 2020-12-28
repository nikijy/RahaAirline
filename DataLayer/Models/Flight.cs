using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Flight
    {
        [Key]
        public int FlightID { get; set; }
        [Display(Name = " کلاس پرواز")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        public int FlightClassID { get; set; }
        [Display(Name = "مبدا")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(50)]
        public string From { get; set; }
        [Display(Name = "مقصد")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(50)]
        public string Destination { get; set; }
        [Display(Name = "نام شرکت")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [Display(Name = "تاریخ رفت")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        public string Departure { get; set; }
        [Display(Name = "ساعت رفت")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        public string DepartureTime { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
       
        public int Price { get; set; }
        [Display(Name = "ظرفیت")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]

        public int Capacity { get; set; }
        [Display(Name = "تعداد مسافران")]
        public int? Passengers { get; set; }

        public virtual List<FlightReserve> FlightReserves { get; set; }

        public virtual FlightClass FlightClass { get; set; }
        public Flight()
        {

        }
    }
}
