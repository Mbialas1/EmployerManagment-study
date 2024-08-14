using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Application.Dtos
{
    public class ContactInfoDTO
    {
        [EmailAddress]
        public string Email { get; init; }
        [RegularExpression(@"^\d{3}-\d{3}-\d{3}$", ErrorMessage = "Phone number must have format: 000-000-000.")]
        public string PhoneNumber { get; init; }

        public ContactInfoDTO(string Email, string phoneNumber)
        {
            this.Email = Email;
            this.PhoneNumber = phoneNumber;
        }
    }
}
