
using System;
using Business.Implements;
using Business.Interfaces;
using Data.Implements;
using Data.Interfaces;
using Entity.Context;
using Microsoft.EntityFrameworkCore;

namespace Web_Serv
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            // Configura DbContext con SQL Server
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbfaultConnection")));


            // Add services to the container.

            
            


            builder.Services.AddScoped<IModuloData, ModuloData>();
            builder.Services.AddScoped<IModuloBusiness, ModuloBusiness>();

            builder.Services.AddScoped<IPersonData, PersonData>();
            builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();

            builder.Services.AddScoped<IRoleData, RoleData>();
            builder.Services.AddScoped<IRoleBusiness, RoleBusiness>();

            builder.Services.AddScoped<IRoleViewData, RoleViewData>();
            builder.Services.AddScoped<IRoleViewBusiness, RoleViewBusiness>();

            builder.Services.AddScoped<IUserRoleData, UserRoleData>();
            builder.Services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();

            builder.Services.AddScoped<IUserData, UserData>();
            builder.Services.AddScoped<IUserBusiness, UserBusiness>();

            builder.Services.AddScoped<IViewData, ViewData>();
            builder.Services.AddScoped<IViewBusiness, ViewBusiness>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            //Registra IPersonaData y su implementacion


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseCors("AllowSpecificOrigin");
                app.UseSwagger();
                app.UseSwaggerUI();
            }
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
