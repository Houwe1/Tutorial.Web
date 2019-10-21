using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Web.Model;
using Tutorial.Web.Services;

namespace Tutorial.Web.ViewComponents
{
    public class WelcomeViewComponent : ViewComponent
    {
        private readonly IServices<Student> _services;

        public WelcomeViewComponent(IServices<Student> services)
        {
            _services = services;
        }

        public IViewComponentResult Invoke()
        {
            var count = _services.GetAll().Count().ToString();
            return View("Default", count);
        }
    }
}
