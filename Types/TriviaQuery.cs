using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;

namespace appservice_graphql_dotnet.Types
{
    public class TriviaQuery : ObjectGraphType
    {
        public TriviaQuery(QuizData data)
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<QuizType>>>>("quizzes", resolve: context =>
            {
                return data.Quizzes;
            });

            Field<NonNullGraphType<QuizType>>("quiz", arguments: new QueryArguments() {
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the quiz" }
            },
            resolve: (context) => data.FindById(context.GetArgument<string>("id")));
        }
    }
}