using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OpenTrivia_Wrapper
{
    public class Question
    {
        [JsonProperty("category")]
        private readonly string category;

        public OpenTriviaClient.Categories Category
        {
            get
            {
                string category = this.category.Replace(" ", "_").Replace("&", "").Replace(":", "");

                for (int i = 0; i < category.Length; i++)
                {
                    //If there are two consecutive underscores in category, remove one of them.
                    if (i > 0 && (category[i] == '_' && category[i - 1] == '_'))
                    {
                        category = category.Remove(i, 1);
                    }
                }
                return (OpenTriviaClient.Categories)Enum.Parse(typeof(OpenTriviaClient.Categories), category);
            }
            private set { }
        }

        [JsonProperty("type")]
        private readonly string type;

        public OpenTriviaClient.QuestionType Type
        {
            get
            {
                switch(type)
                {
                    case "multiple": return OpenTriviaClient.QuestionType.MultipleChoice; //multiple.
                    case "boolean": return OpenTriviaClient.QuestionType.TrueOrFalse; //true or false
                    default: return OpenTriviaClient.QuestionType.Any_Type; //no type at all.
                }
            }
        }

        [JsonProperty("difficulty")]
        private readonly string difficulty;

        public OpenTriviaClient.Difficulties Difficulty
        {
            get
            {
                return (OpenTriviaClient.Difficulties)Enum.Parse(typeof(OpenTriviaClient.Difficulties), char.ToUpper(difficulty[0]) + difficulty.Substring(1));
            }
        }

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