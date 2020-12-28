using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public int PageID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(150)]
        public string Email { get; set; }
        [Display(Name = "کامنت")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(600)]
        public string CommentText { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        public virtual Page Page { get; set; }
        public virtual Residence Residence { get; set; }
        public Comment()
        {

        }
    }
}
