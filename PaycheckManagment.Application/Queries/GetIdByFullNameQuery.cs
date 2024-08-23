using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycheckManagment.Application.Queries
{
    public record GetIdByFullNameQuery(string FirstName, string LastName) : IRequest<long?>
    {
    }
}
