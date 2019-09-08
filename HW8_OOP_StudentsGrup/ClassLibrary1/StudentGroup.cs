using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public class StudentGroup
    {
        List<StudentsManage> _students = new List<StudentsManage>();
        public string Prepod_name;
        public string Group;
        public int Count
        {
              // Store the value in the field.
            set
            {
                  
                    Console.WriteLine("the group is overflow");
           
            }
        }

        public StudentGroup(string prepod_name, string group, List<StudentsManage> students, int count)
        {
            Prepod_name = prepod_name;
            Group = group;
            _students.AddRange(students);
        }
    }
}