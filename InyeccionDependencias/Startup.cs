using InyeccionDependencias.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InyeccionDependencias
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /*
             * Existen 3 ciclos de vidas diferentes:
             * Scoped: el alcance es por http, por cada recarga del navegador se crea un unica instancia de los elementos de la pagina
             * Transcient: el alcance es transitivo, se crea una instancia diferente por cada elemento de la pagina asi pertenezca a una misma clase
             * Singleton: el alcance es de servidor, se instancia una unica vez al compilar el servidor.
             */

            services.AddSingleton<IEmailService, EmailServiceDummy>();
            services.AddScoped<IServicioA, ServicioA>();
            services.AddScoped<IServicioB, ServicioB>();
            services.AddScoped<IServicioC, ServicioC>();
            services.AddScoped<IServicioD, ServicioD>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
