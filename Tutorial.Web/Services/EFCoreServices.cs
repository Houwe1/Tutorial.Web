using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutorial.Web.Data;
using Tutorial.Web.Model;
using Tutorial.Web.ViewModels;

namespace Tutorial.Web.Services
{
    public class EFCoreServices : IServices<Student>
    {
        private readonly DataContext _context;

        public EFCoreServices(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public Student Add(Student newModel)
        {
            _context.Add(newModel);
            _context.SaveChanges();
            return newModel;
        }
    }
}
