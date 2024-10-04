using MediatR;

namespace JobGuard.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>;
