using MediatR;

namespace CQRS;

public interface ICommand<out TResponse> : IRequest<TResponse>;