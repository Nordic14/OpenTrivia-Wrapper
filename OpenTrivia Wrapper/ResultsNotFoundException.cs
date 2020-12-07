namespace OpenTrivia_Wrapper
{

    [System.Serializable]
    public class ResultsNotFoundException : System.Exception
    {
        public ResultsNotFoundException() { }
        public ResultsNotFoundException(string message) : base(message) { }
        public ResultsNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected ResultsNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
