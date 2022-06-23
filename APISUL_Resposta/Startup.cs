using APISUL_Resposta.Interface;
using APISUL_Resposta.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISUL_Resposta
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCors();

            services.AddHttpContextAccessor();
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            services.AddMvc().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                o.SerializerSettings.ContractResolver = new DefaultContractResolver(); //Change results to PascalCase
            });

            //services
            //    .AddControllers()
            //    .AddNewtonsoftJson(options =>
            //        options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            services.AddTransient<IElevadorService, ElevadorService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APISUL_Resposta", Version = "v1" });
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APISUL_Resposta v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}