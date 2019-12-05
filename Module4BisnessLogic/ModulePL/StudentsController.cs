using ModuleBL;
using ModuleBL.Models;
using ModulePL.PostModels;
using ModulePL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModulePL
{
    public class StudentsController
    {
        public StudentViewModel GetById(int id)
        {
            var service = new StudentService();

            var student = service.GetById(id);

            return new StudentViewModel
            {
                Age = student.Age.GetValueOrDefault(),
                FullName = $"{student.FirstName} {student.Lastname}",
                Payments = student.Payments.Select(payment => new PaymentViewModel
                {
                    Date = payment.Date,
                    Value = payment.Value
                })
            };
        }

        public void AddStudent(AddStudentPostModel student)
        {
            if (student.Payments.Count() == 0 || student.Payments==null)
                throw new ArgumentException("no payments");
            var studentModel = new StudentModel()
            {
                FirstName = student.FirstName,
                Lastname = student.Lastname,
                Age = student.Age,
                Payments =  student.Payments.Select(p => new PaymentModel
                {
                    Date = p.Date,
                    Value = p.Value
                })                     
               

        };
            var service = new StudentService();
            service.AddStudent(studentModel);
         
        }
        public List<StudentsPostViewModel> GetStudents(int N)
        {
            var service = new StudentService();

           List<StudentsPostViewModel> students = service.GetStudents(N).Select(x => new StudentsPostViewModel
           {
                FullName = $"{x.FirstName} {x.Lastname}",
                Sum = x.Payments.Sum(y=>y.Value)
            }
            ).ToList();


            return students;
        }
    }
}
