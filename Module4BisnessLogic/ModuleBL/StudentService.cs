using ModuleBL.Models;
using ModuleDal;
using ModuleDal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleBL
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public StudentModel GetById(int id)
        {
            var studentEntity = _studentRepository.GetById(id);

            if (studentEntity == null)
                throw new ArgumentException("Student not fount");

            var resultStudent = new StudentModel
            {
                FirstName = studentEntity.FirstName,
                Lastname = studentEntity.LastName,
            };

            resultStudent.Payments = studentEntity.Payments.Select(payment => new PaymentModel
            {
                Student = resultStudent,
                Value = payment.Value,
                Date = payment.Date
            });

            return resultStudent;
        }

        public void  AddStudent(StudentModel student)
        {
            
            Student studentresult = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.Lastname,
                Age=student.Age,
                Payments = student.Payments.Select(p => new Payment
                {
                    Value = p.Value,
                    Date = p.Date

                }).ToList()
            
            };
           _studentRepository.AddStudent(studentresult);
          
        }
        public IEnumerable<StudentModel> GetStudents(int N)
        {
            if (N == 0)
                throw new ArgumentException("N expected");
            IEnumerable<StudentModel> students = _studentRepository.GetStudents(N)
            .Select(x => new StudentModel
            {
                FirstName = x.FirstName,
                Lastname = x.LastName,
                Age = x.Age,
                Payments = x.Payments.Select(p => new PaymentModel()
                {
                    Id = p.Id,
                    Date = p.Date,
                    Value=p.Value,
                    Student = new StudentModel()
                    {
                        Id = p.Student.Id,
                        FirstName = p.Student.FirstName,
                        Lastname = p.Student.LastName,
                        Age = p.Student.Age
                    }
                })
            });

            return students;

        }



    }
}
