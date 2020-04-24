using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaAquisicao.Api.Data;
using SistemaAquisicao.Api.Data.Repositories;

namespace SistemaAquisicao.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Injeção de dependência
            services.AddScoped<DataContext, DataContext>(); //Cria um item por requisição. Toda a veze que for solicitado, será criado apenas uma instancia.
            services.AddScoped<EstoqueRepository, EstoqueRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();            

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
