using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pokemons.Types.Application.UseCase;
using Pokemons.Types.Domain.Service;
using Pokemons.Types.Persistence;

namespace Pokemons.Types.Api
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
            ConfigureUseCases(services);
            ConfigureDomainServices(services);
            ConfigureRepositories(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokemon.Type.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokemon.Type.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureUseCases(IServiceCollection services)
        {
            services.AddScoped<GetPokemonTypes>();
        }

        private void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<PokemonTypeSearcher>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<PokemonTypeRepository, PokeApiPokemonTypeRepository>();
        }
    }
}
