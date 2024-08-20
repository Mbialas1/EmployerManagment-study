using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycheckManagment.Application.Dtos
{
    public class AddPaycheckUserDTO
    {
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must contains only letter")]
        public string FirstName { get; private set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must contains only letter")]
        public string LastName { get; private set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "The field must contain only numbers.")]
        public string Salary { get; private set; }

        public AddPaycheckUserDTO(string firstName, string lastName, string Salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = Salary;
        }
    }
}
