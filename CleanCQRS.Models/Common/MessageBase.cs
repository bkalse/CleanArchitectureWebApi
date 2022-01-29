using System;
using System.Threading;

namespace CleanCQRS.Models.Common
{
    public class MessageBase<TResponse> : IMessage<TResponse>
    {
        private static long _sequenceId;
        public Guid MessageId { get; set; }
        public Guid SessionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public long SequenceId { get; set; }

        public MessageBase()
        {
            MessageId = Guid.NewGuid();
            TimeStamp = DateTime.UtcNow;
            SequenceId = Interlocked.Increment(ref _sequenceId);
        }
    }
}
