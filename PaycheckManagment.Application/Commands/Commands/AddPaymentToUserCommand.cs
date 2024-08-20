using MediatR;
using PaycheckManagment.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycheckManagment.Application.Commands.Commands
{
    public record AddPaymentToUserCommand : IRequest<bool>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Salary { get; init; }

        public AddPaymentToUserCommand(AddPaycheckUserDTO addPaycheckUserDTO)
        {
            this.FirstName = addPaycheckUserDTO.FirstName;
            this.LastName = addPaycheckUserDTO.LastName;
            this.Salary = addPaycheckUserDTO.Salary;
        }
    }
}
