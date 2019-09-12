using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Web.Model;

namespace Tutorial.Web.ViewModels
{
    public class StudentCreateViewModel
    {
        [Display(Name = "名"), Required, MaxLength(10)]
        public string FirstName { get; set; }

        [Display(Name = "姓"), Required, MaxLength(10)]
        public string LastName { get; set; }

        [Display(Name = "出生日期"), DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Display(Name = "性别")]
        public Gender Gender { get; set; }
    }
}
