using CleanCQRS.Models.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCQRS.Application.Common
{
    public abstract class CommonRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class, IResponse, new()
    {
        protected abstract Task<TResponse> Execute(TRequest request, CancellationToken cancellationToken);
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Execute(request, cancellationToken);
            }
            catch (Exception ex)
            {
                var response = new TResponse()
                {
                    Succeeded = false,
                    Errors = new[] { ex.Message },
                    Message = ex.ToString()
                };

                return response;
            }
        }
    }
}
