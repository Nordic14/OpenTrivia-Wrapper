using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenTrivia_Wrapper
{
    public class Question
    {
        [JsonProperty("category")]
        public string Category { get; private set; }


        [JsonProperty("type")]
        public string Type { get; private set; }


        [JsonProperty("difficulty")]
        public string difficulty { get; private set; }

        [JsonProperty("question")]
        public string Value { get; private set; }

        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; private set; }

        [JsonProperty("incorrect_answers")]
        public List<string> IncorrectAnswers { get; private set; }
    }

    internal class QuestionResults
    {
        [JsonProperty("response_code")]
        public int ResponseCode { get; private set; }

        [JsonProperty("results")]
        public List<Question> Questions { get; private set; }
    }


}