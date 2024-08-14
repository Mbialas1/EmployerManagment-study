using EmployerManagment.Application.Commands.Commands;
using EmployerManagment.Application.Dtos;
using EmployerManagment.Domain.Entities;
using EmployerManagment.Domain.Services;
using EmployerManagment.Domain.ValueObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Application.Commands.Handlers
{
    public record CreateNewEmployeeCommandHandler : IRequestHandler<CreateNewEmployeeCommand, long>
    {
        private readonly IEmployeeRepository _repository;

        public CreateNewEmployeeCommandHandler(IEmployeeRepository repository)
        {
            this._repository = repository;
        }

        public async Task<long> Handle(CreateNewEmployeeCommand command, CancellationToken cancellationToken)
        {
            Employee newEmployee = Employee.
                Create(0, command.CreateEmployeeDTO.FirstName, command.CreateEmployeeDTO.LastName, MappingContanctInfo(command.CreateEmployeeDTO.ContactInfo), new Position());

            long result = await _repository.AddNewEmployee(newEmployee);

            return result;
        }

        private ContactInfo MappingContanctInfo(ContactInfoDTO contactInfoDTO) => 
            new ContactInfo(contactInfoDTO.Email, contactInfoDTO.PhoneNumber);
    }
}
