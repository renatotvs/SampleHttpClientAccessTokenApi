using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SampleHttpClientAccessTokenApi.Config;
using SampleHttpClientAccessTokenApi.Clients;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace SampleHttpClientAccessTokenApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Add Config settings
            services.Configure<EndpointSettings>(Configuration.GetSection("EndpointSettings"));

            //Add HttpClient
            services.AddHttpClient<ITokenClient, TokenClient>();

            //services.AddTransient<IDbConnection, SqlConnection>((service) => { return new SqlConnection(Configuration.GetConnectionString("BD")); });
            //services.AddTransient<IDbContext, DbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

        }
    }
}
