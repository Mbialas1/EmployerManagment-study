using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Domain.Entities
{
    public class Position
    {
        public string Title { get; private set; }
        public string Department { get; private set; }

        public Position()
        {
            this.Title = string.Empty;
            this.Department = string.Empty; 
        }
        public Position(string title, string department)
        {
            Title = title;
            Department = department;
        }
    }
}
