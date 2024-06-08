using KafkaFlow;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RoomService.Core.Abstraction;
using RoomService.Core.Service;
using RoomService.Domain.Entities;
using RoomService.Infrastructure.Data;
using RoomService.Infrastructure.Repositories;
using Serilog;
using ServiceRoom.core.service;


namespace RoomService.API.Extensions
{
    public static class ServiceRegistrations
    {
        public static void ConfigureKafka(this IServiceCollection services)
        {


            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: false)
              .Build();
           services.AddSingleton<IKafKaPublisherService, KafkaPublisherService>();
         
           
           
        }
       


        public static void AppServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            
            
            services.AddDbContext<AppDbContext>(options =>
            
            options.UseNpgsql(
              configuration.GetConnectionString("DefaultConnection"),

               b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)), ServiceLifetime.Transient);


            services.AddIdentity<UserModel, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                
                
            })
           .AddEntityFrameworkStores<AppDbContext>()
           .AddDefaultTokenProviders();

           
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddControllers();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IBidService, Core.Services.BidService>();   
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithMethods("GET", "PUT", "DELETE", "POST")
                    );
            });

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .CreateLogger();

        }

      
        
        
        
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.AddSwaggerGen
                (g =>
                {
                    g.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Auction Room Management API",
                        Description = "Documentation for Auction Room Management API"

                    });

                });
           }
    }
}