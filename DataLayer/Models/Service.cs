using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(100)]
        public String Name { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(450)]
        [DataType(DataType.MultilineText)]
        public string ServiceText { get; set; }

        public Service()
        {
            
        }
    }
}
