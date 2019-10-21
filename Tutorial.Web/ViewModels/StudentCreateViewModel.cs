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
        [Display(Name = "FirstName"), Required, MaxLength(10)]
        public string FirstName { get; set; }

        [Display(Name = "LastName"), Required, MaxLength(10)]
        public string LastName { get; set; }

        [Display(Name = "BirthDay"), DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
    }
}
