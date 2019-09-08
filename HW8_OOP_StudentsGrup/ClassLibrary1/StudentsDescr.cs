using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class StudentsDescr
    {
        public StudentsDescr( string name, int group,string prepod)
        {
        
            Name = name;
            this.group = group;
            Prepod = prepod;

        }

        public string Name { get; set; }

        public int Group;
        public int group
        {
            // Return the value stored in a field.
            get            {  return Group; }
            // Store the value in the field.
            set
            {

                
               if (StudentsManage.CountStudentsGroup(value))
                {
                    Console.WriteLine("Group overflow");
                    Group = 1;
                 
                }
                else
                {
                    Group = value;
                }
            }
        }
        public string Prepod { get; set; }

    }
}
