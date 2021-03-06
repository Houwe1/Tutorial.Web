﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Tutorial.Web.Model;
using Tutorial.Web.Services;
using Tutorial.Web.ViewModels;

namespace Tutorial.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IServices<Student> _repository;

        public HomeController(IServices<Student> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            //#region 6.Controller 返回View
            ////return Content("Hello From HomeController");
            ////var st = new Student
            ////{
            ////    Id = 1,
            ////    FirstName = "Nick",
            ////    LastName = "Carter"
            ////};
            ////使用Razor引擎
            ////使用接口返回指定类型
            //#endregion

            //#region 7.ViewModel
            //var list = _repository.GetAll();

            //var vms = list.Select(x => new StudentViewModel()
            //{
            //    Id = x.Id,
            //    Name = $"{x.FirstName} {x.LastName}",
            //    Age = DateTime.Now.Subtract(x.BirthDay).Days / 365,
            //    Gender = x.Gender
            //});

            //var vm = new HomeIndexViewModel()
            //{
            //    Student = vms
            //};
            //Response.Cookies.Append("17uCNRefId", "532176916");
            //#endregion
            return View("~/Views/Home/Index.cshtml");
            
        }


        #region 07.ViewModel

        public IActionResult Detail(int id)
        {
            var student = _repository.GetById(id);
            if (student == null)
            {
                RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        #endregion

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentCreateViewModel student)
        {
            #region 09.Model验证
            if (ModelState.IsValid)
            {
                var newStudent = new Student()
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BirthDay = student.BirthDay,
                    Gender = student.Gender
                };
                var newModel = _repository.Add(newStudent);

                return RedirectToAction(nameof(Detail), new {id = newModel.Id});
            }
            return View();
            #endregion
        }

        public IActionResult Test()
        {
            bool login = Request.Cookies["SecureToken"] != null && !string.IsNullOrEmpty(Request.Cookies["SecureToken"]) ? true : false;
            var a =Request.Host.Value + Request.Headers["HeaderReferer"].ToString();
            return Redirect(a);
        }
    }
}
