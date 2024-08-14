using EmployerManagment.Domain.Entities;
using EmployerManagment.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Application.Dtos
{
    public class CreateEmployeeDTO
    {
        public int Id { get; private set; } = 0;
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must contains only letter")]
        public string FirstName { get; private set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must contains only letter")]
        public string LastName { get; private set; }
        public ContactInfoDTO ContactInfo { get; private set; }

        public CreateEmployeeDTO(string firstName, string lastName, ContactInfoDTO contactInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContactInfo = contactInfo;
        }
    }
}
