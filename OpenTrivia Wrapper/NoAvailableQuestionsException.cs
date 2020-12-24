using System;

namespace OpenTriviaSharp
{

    [Serializable]
    public class NoAvailableQuestionsException : Exception
    {
        public NoAvailableQuestionsException() { }
        public NoAvailableQuestionsException(string message) : base(message) { }
        public NoAvailableQuestionsException(string message, Exception inner) : base(message, inner) { }
        protected NoAvailableQuestionsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
