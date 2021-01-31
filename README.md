# OpenTrivia-Wrapper: A wrapper for Open Trivia API
A simple yet powerful wrapper for the [Open Trivia API](https://opentdb.com/api_config.php), written in C#.
Might be slightly unstable, because it's still in development.

# Usage:

**Note:** The wrapper has a default value for all fields (except for Token):
1. ANY for CATEGORY.
2. ANY for the QUESTION_TYPE.
3. ANY for the DIFFICULTY.
4. 1 for the number of questions returned per call.


```csharp
//Allows you to access the API. Although not recommended, you may create several instances of this class.
OpenTriviaClient client = new OpenTriviaClient();

//If you don't want repeated questions, make sure to use a token, by calling the UpdateToken method.
client.UpdateToken();
```

# Examples:
**Retrieving 5 random multiple choice questions about computers:**
```csharp
List<Question> questions = await client.RetrieveQuestions(5, category:Category.COMPUTERS, questionType: QuestionType.MULTIPLE);
```

**Retrieving 10 hard true or false questions about animals:**
```csharp
List<Question> questions = await client.RetrieveQuestions(10, category:Category.ANIMALS, difficulty: Difficulty.HARD, QuestionType.TRUE_OR_FALSE);
```

**Retrieving 20 hard questions about anything:**
```csharp
List<Question> questions = await client.RetrieveQuestions(20, difficulty: Difficulty.Hard);
```
