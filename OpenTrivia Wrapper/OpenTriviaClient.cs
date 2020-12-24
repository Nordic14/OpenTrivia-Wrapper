using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenTriviaSharp
{
    /// <summary>
    /// Allows you to access the API. Although not recommended, you may create several instances of this class.
    /// </summary>
    public class OpenTriviaClient
    {
        #region fields
        private static readonly HttpClient Client;

        /// <summary>
        /// The API base URL.
        /// </summary>
        internal const string BASE_URL = "https://opentdb.com/api.php"; 

        /// <summary>
        /// Entirely optional. If specified, the API will never retrieve the same question twice.
        /// Will be deleted after 6 hours of inactivity.
        /// </summary>
        public string Token { get; set; }
        #endregion  


        static OpenTriviaClient()
        {
            //Prevents the client from searching for a proxy before making a request, making it slightly faster.
            HttpClientHandler handler = new HttpClientHandler
            {
                UseProxy = false,
                Proxy = null,
            };

            Client = new HttpClient(handler);
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        /// <summary>
        /// Retrieves questions based on the settings.
        /// </summary>
        /// <returns>A list of questions</returns>
        public async Task<List<Question>> RetrieveQuestions(int amount = 1, int category = Category.ANY, string difficulty = Difficulty.ANY, string questionType = QuestionType.ANY)
        {
            string categoryString = category != Category.ANY ? $"&category={category}" : "";
            string difficultyString = difficulty != Difficulty.ANY ? $"&difficulty={difficulty}": "";
            string typeString = questionType != QuestionType.ANY ? $"&type={questionType}" : "";

            string url = $"{BASE_URL}?amount={(amount > 0 ? amount : 1)}{categoryString}{difficultyString}{typeString}{(Token != null ? $"&token={Token}" : "")}";

            QuestionResults questions = null;
            using (HttpResponseMessage msg = await Client.GetAsync(url))
            {
                questions = await msg.Content.ReadAsAsync<QuestionResults>();
            }

            switch (questions.ResponseCode)
            {
                case 1: throw new NotEnoughResultsException("Number too high.\nTry a smaller number instead.");
                case 2: throw new InvalidParameterException("Invalid parameter.\nCheck your parameters and try again.");
                case 3: //Refreshes the token and calls this function again.
                    await this.SetToken();
                    return await this.RetrieveQuestions(amount, category, difficulty, questionType);
                
                case 4: throw new NoAvailableQuestionsException("No possible questions for the specified query.");

                default: return questions.Questions; //In case of success.
            }
        }

        /// <summary>
        /// Call this function to set the client token property.
        /// If a token is specified, the app won't return the same question twice.
        /// </summary>
        ///
        public async Task SetToken()
        {
            string token;

            using (HttpResponseMessage msg = await Client.GetAsync("https://opentdb.com/api_token.php?command=request"))
            {
                if (msg.IsSuccessStatusCode)
                {
                    JObject obj = JsonConvert.DeserializeObject<JObject>(await msg.Content.ReadAsStringAsync());
                    token = (string)obj["token"];

                    this.Token = token;

                }
            }
        }

        private async Task RefreshToken() { 
            using (HttpResponseMessage msg = await Client.GetAsync($"https://opentdb.com/api_token.php?command=reset&token={Token}"))
            {

            }
        }
        
    }
}
