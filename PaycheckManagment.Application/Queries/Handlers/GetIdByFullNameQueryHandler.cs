using EmployerManagment.Application.Dtos;
using MediatR;
using Newtonsoft.Json;
using PaycheckManagment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycheckManagment.Application.Queries.Handlers
{
    public record GetIdByFullNameQueryHandler : IRequestHandler<GetIdByFullNameQuery, long?>
    {
        private readonly IEmployerManagmentService _employerSerice;

        public GetIdByFullNameQueryHandler(IEmployerManagmentService _employerService)
        {
            this._employerSerice = _employerService;
        }

        public async Task<long?> Handle(GetIdByFullNameQuery command, CancellationToken cancellationToken)
        {
            long? result = null;

            ShortEmployeeDTO dto = new(command.FirstName, command.LastName);
            string jsonContent = JsonConvert.SerializeObject(dto);
            result = await _employerSerice.GetIdUserByFullName(jsonContent);

            return result;
        }
    }
}
