using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Domain.ValueObject
{
    public record ContactInfo 
    {
        public string Email { get; init; }
        public string PhoneNumber { get; init; }    
        public ContactInfo(string email, string phoneNumber)
        {
            if(string.IsNullOrWhiteSpace(Email))
                throw new ArgumentException("Email cannot be empty", nameof(this.Email));
            if (string.IsNullOrWhiteSpace(PhoneNumber))
                throw new ArgumentException("Phone number cannot be empty", nameof(this.PhoneNumber));

            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }
    }
}