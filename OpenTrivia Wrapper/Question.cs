using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenTrivia_Wrapper
{
    public class Question
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("question")]
        public string Value { get; set; }

        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonProperty("incorrect_answers")]
        public List<string> IncorrectAnswers { get; set; }
    }

    internal class QuestionResults
    {
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }

        [JsonProperty("results")]
        public List<Question> Questions { get; set; }
    }


}