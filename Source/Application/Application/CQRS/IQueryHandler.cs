using LP.Common.Application.Contracts.CQRS;
using MediatR;

namespace LP.Common.Application.CQRS;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>;