namespace OpenTriviaSharp
{
    public enum Category
    {
        ANY = 0,
        GENERAL_KNOWLEDGE = 9,
        BOOKS = 10,
        FILMS = 11,
        MUSIC = 12,
        MUSICAL_THEATRES = 13,
        TV = 14,
        VIDEOGAMES = 15,
        BOARD_GAMES = 16,
        NATURE = 17,
        COMPUTERS = 18,
        MATHEMATICS = 19,
        MYTHOLOGY = 20,
        SPORTS = 21,
        GEOGRAPHY = 22,
        HISTORY = 23,
        POLITICS = 24,
        ART = 25,
        CELEBRITIES = 26,
        ANIMALS = 27,
        VEHICLES = 28,
        ENTERTAINMENT_COMICS = 29,
        GADGETS = 30,
        JAPANESE_ANIME_MANGA = 31,
        CARTOONS = 32,
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
