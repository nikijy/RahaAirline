using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FlightReserve
    {
        [Key]
        public int ReserveID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public int FlightID { get; set; }


        [Display(Name = "قیمت")]
        public int Price { get; set; }


        [Display(Name = "تاریخ رزرو")]
        public string DateTime { get; set; }

        public bool IsFinally { get; set; }

        [Display(Name = "تعداد مسافران")]
        public int Passengers { get; set; }

        //public virtual User User { get; set; }
        public virtual Flight Flight { get; set; }


        public FlightReserve()
        {

        }

    }
}
