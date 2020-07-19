using System.Collections.Generic;
using System.Text.Json.Serialization;
using GraphQL.Types;

namespace appservice_graphql_dotnet.Types
{
    public class Quiz
    {
        public string Id
        {
            get
            {
                return Question.ToLower().Replace(" ", "-");
            }
        }
        public string Question { get; set; }
        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; }
        [JsonPropertyName("incorrect_answers")]
        public List<string> IncorrectAnswers { get; set; }
    }

    public class QuizType : ObjectGraphType<Quiz>
    {
        public QuizType()
        {
            Name = "Quiz";
            Description = "A representation of a single quiz.";
            Field(q => q.Id, nullable: false);
            Field(q => q.Question, nullable: false);
            Field(q => q.CorrectAnswer, nullable: false);
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<StringGraphType>>>>("incorrectAnswers");
        }
    }
}