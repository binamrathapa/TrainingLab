using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Employee
    {
        string id;
        public string Name
        {
            get;
            set;
        }

        public Employee(string pid)
        {
            id = pid;
        }

        public string GetEmployeInfo()
        {
            return "Name:"+Name+"\n Id:"+id;
        }
    }
}
