using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ResidenceType
    {
        [Key]
        public int ResidenceTypeID { get; set; }
        [Display(Name = "نوع اقامتگاه")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(150)]
        public string ResidenceKind { get; set; }

        public virtual List<Residence> Residences { get; set; }

        public ResidenceType()
        {

        }
    }
}
