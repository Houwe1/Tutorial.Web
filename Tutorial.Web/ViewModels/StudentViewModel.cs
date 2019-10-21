using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Web.Model;

namespace Tutorial.Web.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
