namespace OpenTrivia_Wrapper
{
    public struct Category
    {
        public const int ANY = 0;
        public const int GENERAL_KNOWLEDGE = 9;
        public const int BOOKS = 10;
        public const int FILMS = 11;
        public const int MUSIC = 12;
        public const int MUSICAL_THEATRES = 13;
        public const int TV = 14;
        public const int VIDEOGAMES = 15;
        public const int BOARD_GAMES = 16;
        public const int NATURE = 17;
        public const int COMPUTERS = 18;
        public const int MATHEMATICS = 19;
        public const int MYTHOLOGY = 20;
        public const int SPORTS = 21;
        public const int GEOGRAPHY = 22;
        public const int HISTORY = 23;
        public const int POLITICS = 24;
        public const int ART = 25;
        public const int CELEBRITIES = 26;
        public const int ANIMALS = 27;
        public const int VEHICLES = 28;
        public const int ENTERTAINMENT_COMICS = 29;
        public const int GADGETS = 30;
        public const int JAPANESE_ANIME_MANGA = 31;
        public const int CARTOONS = 32;
    }

    public struct QuestionType
    {
        public const string ANY = "";
        public const string MULTIPLE = "multiple";
        public const string TRUE_OR_FALSE = "boolean";
    }

    public struct Difficulty
    {
        public const string ANY = "";
        public const string EASY = "easy";
        public const string MEDIUM = "medium";
        public const string HARD = "hard";
    }
}
