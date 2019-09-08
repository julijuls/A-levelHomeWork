using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   
    public class StudentsManage
    {
        static Random RanNum = new Random();

        public static List<StudentsDescr> _studentList;
        public StudentsManage()
        {
            
            _studentList = new List<StudentsDescr>();

            Random rand = new Random();
            for (int i = 0; i <= 3; i++)
            {
                _studentList.Add(new StudentsDescr("Student_"+i, 3,"Assistent" ));
            }
            for (int i = 0; i <= 14; i++)
            {
                _studentList.Add(new StudentsDescr("Student_" + i, 2,"Lector"));
            }
            for (int i = 0; i <= 18; i++)
            {
                _studentList.Add(new StudentsDescr("Student_" + i, 1,"Proffesor"));
            }
        }
        public static StudentsDescr[] ViewStudentsList
        {
            get
            {
                return _studentList.ToArray();

            }
        }
        public static bool CountStudentsGroup(int id_group)
        {
            var count = _studentList.Where(x => x.Group == id_group).Count();
            bool result;
            switch  (id_group)
            {
             case 1:
                    if (count >= 20)
                    { result = true; }
                    else
                    { result = false; }
                break;
            case 2:
                    if (count >= 15)
                    { result = true; }
                    else
                    { result = false; }
                    break;
            case 3:
                    if (count >= 5)
                    { result = true; }
                    else
                    { result = false; }
                    break;
              default:
                    result = false;
                    break;
            }
            return result;
        }
        public void NewStudent(StudentsDescr people)
        {

            _studentList.Add(people);

        }
       // public void List
    }
}
