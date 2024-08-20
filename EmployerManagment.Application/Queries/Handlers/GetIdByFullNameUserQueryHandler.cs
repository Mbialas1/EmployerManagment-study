using EmployerManagment.Application.Commands.Commands;
using EmployerManagment.Application.Queries.Queries;
using EmployerManagment.Domain.Entities;
using EmployerManagment.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Application.Queries.Handlers
{
    public record GetIdByFullNameUserQueryHandler : IRequestHandler<GetIdByFullNameUserQuery, long>
    {
        private readonly IEmployeeRepository _repository;

        public GetIdByFullNameUserQueryHandler(IEmployeeRepository repository)
        {
            this._repository = repository;
        }

        public async Task<long> Handle(GetIdByFullNameUserQuery command, CancellationToken cancellationToken)
        {
            Employee employee = await _repository.FindUserByFullName(command.FirstName, command.LastName);
            if (employee == null)
                throw new ArgumentNullException($"Cannot find user {command.FirstName} {command.LastName}");
            return employee.Id;
        }
    }
}
