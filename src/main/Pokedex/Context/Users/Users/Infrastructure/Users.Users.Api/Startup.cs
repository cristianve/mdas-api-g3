using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Users.Users.Application.UseCase;
using Users.Users.Domain.Repositories;
using Users.Users.Domain.Services;
using Users.Users.Persistence;

namespace Users.Users.Api
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
            ConfigureCache(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Users.Users.Api", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Users.Users.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void ConfigureUseCases(IServiceCollection services)
        {
            services.AddScoped<CreateUser>();
            services.AddScoped<AddPokemonToUserFavorites>();
            services.AddScoped<GetPokemonUserFavorites>();
        }

        private void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<UserCreator>();
            services.AddScoped<PokemonFavoriteCreator>();
            services.AddScoped<UserFinder>();
            services.AddScoped<PokemonFavoriteSearcher>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<UserRepository, InMemoryUserRepository>();
        }

        private void ConfigureCache(IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}