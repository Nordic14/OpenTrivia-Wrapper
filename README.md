# OpenTrivia-Wrapper: A wrapper for Open Trivia API
A simple yet powerful wrapper for the [Open Trivia API](https://opentdb.com/api_config.php) written in C#.

# Usage:
```csharp
//Allows you to access the API. Although not recommended, you may create several instances of this class.
OpenTriviaClient client = new OpenTriviaClient 
{
    Amount = 10, //Default is 1, maximum is 50 (inclusive)
    
    //In order to filter your questions, you can also setup a Category, Difficulty and a type.
};

//If you don't want repeated questions, make sure to use a token, by calling the RetrieveToken method.
client.RetrieveToken();
```

# Examples:
**Retrieving 5 random multiple choice questions about computers:**
```csharp
OpenTriviaClient client = new OpenTriviaClient
{
    Amount = 5,
    Category = OpenTriviaClient.Categories.Science_Computers,
    Type = OpenTriviaClient.QuestionType.MultipleChoice
};

List<Question> questions = await client.RetrieveQuestions();
```

**Retrieving 10 hard true or false questions about animals:**
```csharp
OpenTriviaClient client = new OpenTriviaClient
{
    Amount = 10,
    Category = OpenTriviaClient.Categories.Animals,
    Type = OpenTriviaClient.QuestionType.TrueOrFalse,
    Difficulty = OpenTriviaClient.Difficulties.Hard,
};

List<Question> questions = await client.RetrieveQuestions();
```
