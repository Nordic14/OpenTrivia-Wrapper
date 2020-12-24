using System;

namespace OpenTriviaSharp
{

    [Serializable]
    public class NotEnoughResultsException : Exception
    {
        public NotEnoughResultsException() { }
        public NotEnoughResultsException(string message) : base(message) { }
        public NotEnoughResultsException(string message, Exception inner) : base(message, inner) { }
        protected NotEnoughResultsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
