using appservice_graphql_dotnet.Types;
using GraphQL.Types;

namespace appservice_graphql_dotnet
{
    public class TriviaSchema : Schema
    {
        public TriviaSchema(TriviaQuery query)
        {
            Query = query;
        }
    }
}