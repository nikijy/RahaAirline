using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FlightClass
    {
        [Key]
        public int FlightClassID { get; set; }
        [Display(Name = "نوع کلاس")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(150)]
        public string FlightClassKind { get; set; }

        public virtual List<Flight> Flights { get; set; }

        public FlightClass()
        {

        }
    }
}
