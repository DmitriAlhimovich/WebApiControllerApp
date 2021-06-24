using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiControllerApp
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController
    {
        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            var students = StudentsRepository.Students;
            return students;
        }

        [HttpGet("{name}")]
        public Student GetByName(string name)
        {
            
            var student = StudentsRepository.Students.FirstOrDefault(s => s.Name == name);
            return student;
        }

        [HttpPost]
        public Student Add([FromBody]Student student)
        {
            StudentsRepository.Students.Add(student);
            return student;
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
    }

    public class StudentsRepository
    {
        public static List<Student> Students =>
            new()
            {
                new Student { Name = "Alex", Course = 2 },
                new Student { Name = "Max", Course = 3 },
                new Student { Name = "Eugene", Course = 1 },
            };
    }
}
