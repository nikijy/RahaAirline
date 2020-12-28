using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Place
    {
        [Key]
        public int PlaceID { get; set; }
        [Display(Name = "کشور")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(150)]
        public string Country { get; set; }
        [Display(Name = "شهر")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(150)]
        public string City { get; set; }
        [Display(Name = "تصویر")]
        public string Image { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        public int Price { get; set; }
        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        public Place()
        {

        }
    }
}
