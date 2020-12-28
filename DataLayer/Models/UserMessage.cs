using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserMessage
    {
        [Key]
        public int MessageID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل را به درستی وارد کنید")]
        public string Email { get; set; }
        [Display(Name = "موضوع")]
        [MaxLength(80)]
        public string Subject { get; set; }
        [Display(Name = "پیام")]
        [Required(ErrorMessage = " لطفا{0} را وارد کنید")]
        [MaxLength(500)]
        public string Text { get; set; }

        public UserMessage()
        {
            
        }
    }
}
