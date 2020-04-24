using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SCA.ModuloAtivo.Api.Authorization;
using SCA.ModuloAtivo.Api.Data;
using SCA.ModuloAtivo.Api.Data.Repositories;
using System.Text;

namespace SCA.ModuloAtivo.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc(); //Middleware MVC            

            //Injeção de dependência
            services.AddScoped<DataContext, DataContext>(); //Cria um item por requisição. Toda a veze que for solicitado, será criado apenas uma instancia.
            services.AddScoped<AtivoRepository, AtivoRepository>();
            services.AddScoped<ClasseRepository, ClasseRepository>();
            //services.AddTransient //Cria vários itns por requisição. Toda a veze que for solicitado, será criado uma nova instancia.

            //Realizando a validação do token
            //Authorization
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, //precisa validar a chave
                    IssuerSigningKey = new SymmetricSecurityKey(key), //tipo de chave simetrica
                    ValidateIssuer = false, //usado em aplicação distribuida
                    ValidateAudience = false //usado em aplicação distribuida
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
