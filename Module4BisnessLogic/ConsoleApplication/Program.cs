using ModulePL;
using ModulePL.PostModels;
using ModulePL.ViewModels;
using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ctrl = new StudentsController();
          
            AddStudentPostModel studentModel = new AddStudentPostModel()
            {
                FirstName = "Петя",
                Lastname = "Пупкин",
                Age = 34,
                Payments = new List<PaymentPost>()
                {
                    new PaymentPost()
                    {

                            Date = Convert.ToDateTime("2019-02-20"),
                            Value = 60
                    }

                }
            };
            ctrl.AddStudent(studentModel);
            var student = ctrl.GetById(1);
          
            var studentList = ctrl.GetStudents(80);
            foreach (var stud in studentList)
                Console.WriteLine($"{stud.FullName} {stud.Sum}");
        }
    }
}
