using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsManage _studentList = new StudentsManage();
            Console.WriteLine("1-add; 2-all;3-GroupList;4-exit;");
            int answer = Convert.ToInt32(Console.ReadLine());
            while (answer == 1 || answer == 2 || answer == 3 )
            {
                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Enter name of new student:");
                        string name_student = Console.ReadLine();
                        Console.WriteLine("Enter group_id  of new student:");
                        string group_id = Console.ReadLine();
                        int testNum;
                        while (!int.TryParse(group_id, out testNum))
                        {
                            Console.WriteLine("Enter int");
                            group_id = Console.ReadLine();
                        }
                        string prepod_name;
                        switch (group_id)
                        {
                        case "1":
                                prepod_name = "Proffesor";
                            break;
                        case "2":
                                prepod_name = "Lector";
                                break;
                        case "3":
                                prepod_name = "Assistent";
                                break;
                            default:
                                prepod_name = "Proffessor";
                                break;
                        }
                        _studentList.NewStudent(new StudentsDescr(name_student, Convert.ToInt32(group_id), prepod_name));
                        break;

                    case 2:
                        foreach (StudentsDescr s in StudentsManage.ViewStudentsList)
                        {
                            Console.Write(string.Format("{{0, -{0}}}|", 10), s.Name);
                            Console.Write(string.Format("{{0, -{0}}}|", 2), s.Group);
                            Console.Write(string.Format("{{0, -{0}}}|", 2), s.Prepod);
                            Console.WriteLine();
                        }
                       
                        Console.ReadKey();
                        break;
                    case 3:


                       
                        var GroupList = from student in StudentsManage.ViewStudentsList
                                           group student by student.Prepod into g
                                           select new { Name = g.Key, Count = g.Count() };
                        foreach (var group in GroupList)
                        Console.WriteLine("{0} : {1}", group.Name, group.Count);
                    
                        Console.ReadKey();
                        break;
                }
                Console.WriteLine("1-add; 2-all; 3-GroupList; 4-exit;");
                answer = Convert.ToInt32(Console.ReadLine());
                Console.ReadKey();
            }
          
        }
    }
}
