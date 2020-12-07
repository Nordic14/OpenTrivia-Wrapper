using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenTrivia_Wrapper
{
    /// <summary>
    /// Allows you to access the API. DO NOT CREATE MULTIPLE INSTANCES OF THIS CLASS!
    /// </summary>
    public class OpenTriviaClient
    {
        #region enums
        public enum Difficulties
        {
            Any_Difficulty,
            Easy,
            Medium,
            Hard,
        }

        public enum Categories
        {
            Any_Category,
            General_Knowledge = 9,
            Entertainment_Books,
            Entertainment_Film,
            Entertainment_Music,
            Entertainment_Musicals_Theatres,
            Entertainment_Television,
            Entertainment_Video_Games,
            Entertainment_Board_Games,
            Science_Nature,
            Science_Computers,
            Science_Mathematics,
            Mythology,
            Sports,
            Geography,
            History,
            Politics,
            Art,
            Celebrities,
            Animals,
            Vehicles,
            Entertainment_Comics,
            Science_Gadgets,
            Entertainment_Anime_Manga,
            Entertainment_Cartoons,
        }

        public enum QuestionType
        {
            Any_Type,
            TrueOrFalse,
            MultipleChoice
        }
        #endregion

        #region fields
        private static HttpClient Client;

        /// <summary>
        /// The API base URL.
        /// </summary>
        internal const string BASE_URL = "https://opentdb.com/api.php"; 

        /// <summary>
        /// Entirely optional. If specified, the API will never retrieve the same question twice.
        /// Will be deleted after 6 hours of inactivity.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// If specified, the API returns questions whose difficulty match the selected difficulty.
        /// </summary>
        public Difficulties Difficulty { get; set; }

        /// <summary>
        /// If specified, the API returns a queston based on the selected topic.
        /// </summary>
        public Categories Category { get; set; }

        /// <summary>
        /// If specified, the API returns ques
        /// </summary>
        public QuestionType Type { get; set; }

        /// <summary>
        /// Tells the API how many questions should be retrieved per call.
        /// </summary>
        public int Amount { get; set; }
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
        /// <returns></returns>
        public async Task<List<Question>> RetrieveQuestions()
        {
            string category = this.Category != Categories.Any_Category ? $"&category={(int)this.Category}" : "";
            string difficulty = this.Difficulty != Difficulties.Any_Difficulty ? $"&difficulty={this.Difficulty.ToString().ToLower()}": "";

            string url = $"{BASE_URL}?amount={(this.Amount > 0 ? this.Amount : 1)}{category}{difficulty}";

            QuestionResults questions = null;
            using (HttpResponseMessage msg = await Client.GetAsync(url))
            {
                questions = await msg.Content.ReadAsAsync<QuestionResults>();

                if (questions.ResponseCode != 0) { //If, for some reason, the API returns no results.
                    throw new ResultsNotFoundException("Couldn't find any results that satisfy your query.");
                }
            }

            return questions.Questions;
        }
        
    }
}
