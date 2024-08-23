using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Application.Dtos
{
    public class ShortEmployeeDTO
    {
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must contains only letter")]
        public string FirstName { get; private set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must contains only letter")]
        public string LastName { get; private set; }

        public ShortEmployeeDTO(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
