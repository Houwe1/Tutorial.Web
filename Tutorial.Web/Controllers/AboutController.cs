using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial.Web.Controllers
{
    //5.Controller 路由
    //Data Attitude
    [Route("v2/[controller]/[action]")]
    public class AboutController : Controller
    {
        public string Me()
        {
            return "Dave";
        }

        public string Company()
        {
            return "No Company";
        }


    }
}