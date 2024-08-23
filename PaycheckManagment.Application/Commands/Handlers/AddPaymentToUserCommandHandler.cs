using MediatR;
using PaycheckManagment.Application.Commands.Commands;
using PaycheckManagment.Application.Queries;
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
        private IMediator _mediator { get; init; }
        public AddPaymentToUserCommandHandler(IPaycheckRepository repository, IMediator mediator)
        {
            this._repository = repository;
            this._mediator = mediator;
        }

        public async Task<bool> Handle(AddPaymentToUserCommand command, CancellationToken cancellationToken)
        {
            //Kafka here later
            long? idUser = null;
            idUser = await _mediator.Send(new GetIdByFullNameQuery(command.FirstName, command.LastName));
            if(idUser is null)
                throw new ArgumentNullException($"User of {command.FirstName} {command.LastName} doesnt exist!");



            return false;
        }
    }
}
