using ModuleDal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace ModuleDal
{
    public class StudentRepository
    {
        private readonly ModuleContext _context;
        private readonly string  touy;
        public StudentRepository()
        {
            _context = new ModuleContext();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students
                .Include(x=>x.Payments)
                .FirstOrDefault(x => x.Id == id);
        }
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
      
        }
        public IEnumerable<Student> GetStudents(int N)
        {
            IEnumerable<Student> students = _context.Students.Include(p=>p.Payments).Where(x => x.Payments.Sum(y=>y.Value) < N).ToList();
            return students;

        }
    }
}
