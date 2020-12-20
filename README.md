# OpenTrivia-Wrapper: A wrapper for Open Trivia API
A simple yet powerful wrapper for the [Open Trivia API](https://opentdb.com/api_config.php), written in C#.

# Usage:
```csharp
//Allows you to access the API. Although not recommended, you may create several instances of this class.
OpenTriviaClient client = new OpenTriviaClient 
{
    Amount = 10, //Default is 1, maximum is 50 (inclusive)
};

//If you don't want repeated questions, make sure to use a token, by calling the UpdateToken method.
client.UpdateToken();
```
**Note:** If you want to filter a question per topic, difficulty or type (either true or false or multiple choice), make sure to specify them in the client definition.

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

**Retrieving 20 hard questions about anything:**
```csharp
OpenTriviaClient client = new OpenTriviaClient
{
    Amount = 20,
    Difficulty = OpenTriviaClient.Difficulties.Hard,
};

List<Question> questions = await client.RetrieveQuestions();
```
