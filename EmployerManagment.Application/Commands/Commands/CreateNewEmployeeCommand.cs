using EmployerManagment.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Application.Commands.Commands
{
    public record CreateNewEmployeeCommand(CreateEmployeeDTO CreateEmployeeDTO) : IRequest<long>
    {
    }
}
