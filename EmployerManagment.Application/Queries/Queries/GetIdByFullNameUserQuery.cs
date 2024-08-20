using EmployerManagment.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Application.Queries.Queries
{
    public record GetIdByFullNameUserQuery : IRequest<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public GetIdByFullNameUserQuery(ShortEmployeeDTO shortEmployeeDTO)
        {
            FirstName = shortEmployeeDTO.FirstName;
            LastName = shortEmployeeDTO.LastName;
        }
    }
}
