using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenTrivia_Wrapper
{
    /// <summary>
    /// Allows you to access the API. Although not recommended, you may create several instances of this class.
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
            Entertainment_Japanese_Anime_Manga,
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

        /// <summary>
        /// If specified, the API returns questions whose difficulty match the selected difficulty.
        /// </summary>
        public Difficulties Difficulty { get; set; }

        /// <summary>
        /// If specified, the API returns a queston based on the selected topic.
        /// </summary>
        public Categories Category { get; set; }

        /// <summary>
        /// If specified, the API returns a question whose type (either true or false or multiple choice) matches tje selected type.
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
            string type = "";

            switch (this.Type)
            {
                case QuestionType.MultipleChoice: type = "&type=multiple"; break;
                case QuestionType.Any_Type: type = "&type=boolean"; break;
            }

            string url = $"{BASE_URL}?amount={(this.Amount > 0 ? this.Amount : 1)}{category}{difficulty}{type}{(Token != null ? $"&token={Token}" : "")}";

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

        /// <summary>
        /// Use this method to set the token property of an OpenTrivia object.
        /// If a token is specified, the app won't return the same question twice.
        /// </summary>
        /// <returns></returns>
        public async void UpdateToken()
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
        
    }
}
