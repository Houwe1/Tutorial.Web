using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Web.Model;

//namespace Tutorial.Web.Services
//{
//    public class InMemoryRepository : IRepository <Student>
//    {
//        private readonly List<Student> _student;

//        public InMemoryRepository()
//        {
//            _student = new List<Student>
//            {
//                new Student
//                {
//                    Id = 1,
//                    FirstName = "One",
//                    LastName = "Carter",
//                    BirthDay = new DateTime(1990, 2, 8)

//                },
//                new Student
//                {
//                    Id = 2,
//                    FirstName = "Two",
//                    LastName = "Carter",
//                    BirthDay = new DateTime(1988, 2, 8)
//                },
//                new Student
//                {
//                    Id = 3,
//                    FirstName = "Three",
//                    LastName = "Carter",
//                    BirthDay = new DateTime(2000, 2, 8)
//                }
//            };
//        }

//        public IEnumerable<Student> GetAll()
//        {
//            return _student;
//        }

//        public Student GetById(int id)
//        {
//            return _student.FirstOrDefault(m => m.Id == id);
//        }

//        public Student Add(Student newModel)
//        {
//            var maxid = _student.Max(m => m.Id);
//            newModel.Id = maxid + 1;
//            _student.Add(newModel);
//            return newModel;
//        }
//    }
//}
