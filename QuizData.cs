using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using appservice_graphql_dotnet.Types;

namespace appservice_graphql_dotnet
{
    public class QuizData
    {
        private class OtdbResponse
        {
            public IEnumerable<Quiz> Results { get; set; }
        }

        public IEnumerable<Quiz> Quizzes { get; set; }

        public QuizData(HttpClient http)
        {
            var t = http.GetStringAsync("https://opentdb.com/api.php?amount=100&category=15&type=multiple");
            Task.WaitAll(t);

            var results = JsonSerializer.Deserialize<OtdbResponse>(t.Result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Quizzes = results.Results;
        }

        public Quiz FindById(string id) {
            return Quizzes.FirstOrDefault(q => q.Id == id);
        }
    }
}