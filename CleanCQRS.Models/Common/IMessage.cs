using MediatR;
using System;

namespace CleanCQRS.Models.Common
{
    public interface IMessage<TResponse> : IRequest<TResponse>
    {
        Guid MessageId { get; set; }
        Guid SessionId { get; set; }
        DateTime TimeStamp { get; set; }
        long SequenceId { get; set; }
    }
}
