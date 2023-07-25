using DataAccessLayerP26.Data;
using DataAccessLayerP26.Handler;
using DataAccessLayerP26.Repository;
using System.Windows.Input;

namespace CQRSPatternP26
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationContext>();
            builder.Services.AddScoped<IQuery,QueryRepository>();
            builder.Services.AddScoped<DataAccessLayerP26.Repository.ICommand, CommandRepository>();
            builder.Services.AddAutoMapper(typeof(AutomapperHandler));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}