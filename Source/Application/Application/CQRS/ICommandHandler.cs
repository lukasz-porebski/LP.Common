using LP.Common.Application.Contracts.CQRS;
using MediatR;

namespace LP.Common.Application.CQRS;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand;