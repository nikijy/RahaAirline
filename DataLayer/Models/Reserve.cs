using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Reserve
    {
        [Key]
        public int ReserveID { get; set; }
       
        [Required]
        public string UserID { get; set; }
        [Required]
       
        public int ResidenceID { get; set; }

        
        [Display(Name = "قیمت")]
        public int Price { get; set; }

     
        [Display(Name = "تاریخ رزرو")]
        public string DateTime { get; set; }

        public bool IsFinally { get; set; }

        [Display(Name = "تعداد مسافران")]
        public int Passengers { get; set; }
        [Display(Name = "تعداد اتاق")]
        public int RoomNumber { get; set; }
        [Display(Name = "تاریخ ورود")]
        public string CheckIn { get; set; }

        [Display(Name = "تاریخ خروج")]
        public string CheckOut { get; set; }
        //public virtual User User { get; set; }
        public virtual Residence Residence { get; set; }
      
        public Reserve()
        {

        }
    }
}
