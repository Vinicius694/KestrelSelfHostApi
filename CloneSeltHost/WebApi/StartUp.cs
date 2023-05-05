using ICA.Ng.Carpark.WebApi.Controllers;
using ICA.Ng.Carpark.WebApi.Services.v1;
using ICA.Ng.Carpark.WebApi.Services.v1.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ICA.Ng.Carpark.WebApi
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TicketController>();
            services.AddSingleton<ITicketService, TicketService>();
            services.AddHealthChecks();
            services.AddControllers();
            services.AddSwaggerGen();
        }

        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
                options.DocumentTitle = "ICA WEB API";
            }

           );

            app.UseHttpsRedirection();
            app.UseStaticFiles();
        }
    }
}