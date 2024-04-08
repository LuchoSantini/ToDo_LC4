using Microsoft.EntityFrameworkCore;
using To_Do_List_LC4.Context;
using To_Do_List_LC4.Interfaces;
using To_Do_List_LC4.Services;

namespace To_Do_List_LC4
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

            // Conexión a la base de datos (SQLITE)
            builder.Services.AddDbContext<ToDoContext>(dbContextOptions => dbContextOptions.UseSqlite(
            builder.Configuration["DB:ConnectionString"]));

            #region Inyección de dependencias
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IToDoItemService, ToDoItemService>();
            #endregion

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