using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyOwnStore.Database;
using MyOwnStore.Libraries.Session;
using MyOwnStore.Repositories;
using MyOwnStore.Repositories.Contracts;
using MyOwnStore.Libraries.Session;
using MyOwnStore.Libraries.Login;
using System.Net.Mail;
using System.Net;
using MyOwnStore.Libraries.Mail;
using MyOwnStore.Libraries.Middleware;

namespace MyOwnStore
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
            /*Repositorios*/
            services.AddHttpContextAccessor();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<INewsletterRepository, NewsletterRepository>();
            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPicturesRepository, PicturesRepository>();
            /*
             *
             */
            services.AddMemoryCache(); //Guardar dados na memoria
            services.AddSession(options => { });//Adiciona suporte a sessoes
            services.AddScoped<Session>();
            /*
             * Database Context  
             */

            /*
             * SMTP - Importação dos dados de conexão do servidor
             */
            services.AddScoped<SmtpClient>( options => {
                SmtpClient smtp = new SmtpClient()
                {
                    Host = Configuration.GetValue<string>("Email:ServerSMTP"),
                    Port = Configuration.GetValue<int>("Email:ServerPort"),
                    UseDefaultCredentials = false,
                    EnableSsl=true,
                    Credentials = new NetworkCredential(Configuration.GetValue<string>("Email:EmailCredential"), Configuration.GetValue<string>("Email:PasswordCredential"))
                };

                return smtp;
            });
            services.AddScoped<MailSender>();
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("Local")));

            /*
             * MVC Support
             */
            services.AddScoped<Session>();
            services.AddScoped<LoginClient>();
            services.AddScoped<LoginCollaborator>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseBrowserLink();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();//Ativa o uso de cookies
            app.UseSession();//Ativa o uso de sessoes
            app.UseMiddleware<CustomValidateAntiForgeryToken>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
              );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
