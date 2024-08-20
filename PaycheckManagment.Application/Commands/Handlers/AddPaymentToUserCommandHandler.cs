using MediatR;
using PaycheckManagment.Application.Commands.Commands;
using PaycheckManagment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycheckManagment.Application.Commands.Handlers
{
    public record AddPaymentToUserCommandHandler : IRequestHandler<AddPaymentToUserCommand, bool>
    {
        private IPaycheckRepository _repository { get; init; }
        public AddPaymentToUserCommandHandler(IPaycheckRepository repository)
        {
            this._repository = repository;
        }

        public async Task<bool> Handle(AddPaymentToUserCommand command, CancellationToken cancellationToken)
        {
            //Event here - find User and return id
            return false;
        }
    }
}
