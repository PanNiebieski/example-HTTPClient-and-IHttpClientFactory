using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ASPNETHttpClientTester
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("ToDoClient", client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                client.Timeout = new TimeSpan(0, 0, 30);
                client.DefaultRequestHeaders.Clear();
            });

            services.AddHttpClient<TodoTypedClient>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });


        }
    }
}
