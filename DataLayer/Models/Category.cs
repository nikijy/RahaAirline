using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(150)]
        public string Title { get; set; }

        public virtual List<Page> Pages { get; set; }

        public Category()
        {

        }
    }
}