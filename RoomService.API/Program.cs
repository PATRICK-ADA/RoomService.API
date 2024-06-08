
using RoomService.API.Extensions;
using Extensions.NewSeriLog;


public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.


        builder.Services.AppServices(builder.Configuration);
        builder.Services.ConfigureKafka();
        builder.Services.AddSwaggerServices();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        var app = builder.Build();


        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(x => x
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(origin => true)
                  .AllowCredentials());

        app.UseAuthorization();
        app.MapControllers();
        
        app.UseSerilogMigrationSetUpInfo();

        app.Run();
    }
   
}