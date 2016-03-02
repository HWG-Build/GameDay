using System;
using System.Runtime.Serialization;

namespace Domain.Service.CustomExceptions
{
    [Serializable]
    public class EventException : Exception
    {
        public EventException() { }
        public EventException(string message) : base(message) { }
        public EventException(string message, Exception inner) : base(message, inner) { }
        protected EventException(SerializationInfo info,StreamingContext context)
            : base(info, context)
        { }
    }
}
