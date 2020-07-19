using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.Server;
using GraphQL.Types;
using appservice_graphql_dotnet.Types;
using System.Net.Http;

namespace appservice_graphql_dotnet
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<HttpClient>();
            services.AddSingleton<QuizData>();
            services.AddSingleton<QuizQuery>();
            services.AddSingleton<ISchema, TriviaSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            })
            .AddSystemTextJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground();
        }
    }
}
