using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAPI_AlunosVS.Library.Extensions;
using WebAPI_AlunosVS.Library.Services.Interfaces;
using WebAPI_AlunosVS.Library.Services;
using WebAPI_AlunosVS.Library.Repositories.Interfaces;
using WebAPI_AlunosVS.Library.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace WebAPI_AlunosVS.Api
{
    public class Startup
    {
        public readonly IConfiguration _Configuration;

        public Startup(IConfiguration Configuration)
        {
            _Configuration=Configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API Alunos", Version = "v1" });
            });

            services.AddTransient<IAlunoServices, AlunoServices>();
            services.AddTransient<IAlunoRepository, AlunoRepository>();

            services.AddSingleton<IConfiguration>(_Configuration);
            services.AddSingleton<Connection>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAllOrigins");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI para Alunos");
            });

            app.UseMvc();
        }
    }
}
