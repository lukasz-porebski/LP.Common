using MediatR;

namespace LP.Common.Application.Contracts.CQRS;

public interface IQuery<TResult> : IRequest<TResult>;