using Business.Interfaces.Location;
using Business.Interfaces.Security;
using Business.Service.Location;
using Business.Service.Security;
using Data.Implemenst.Location;
using Data.Implemenst.Security;
using Data.Interfaces.Location;
using Data.Interfaces.Security;
using Entity.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Configuracion Cords
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
builder.Services.AddDbContext<AplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbfaultConnection")));

builder.Services.AddScoped<IUserBisness,BusinessUser>();
builder.Services.AddScoped<IDUser, DUser>();
builder.Services.AddScoped<IPersonBusiness, BusinessPerson>();
builder.Services.AddScoped<IDPerson, DPerson>();
builder.Services.AddScoped<IModuleBusiness, BusinessModule>();
builder.Services.AddScoped<IDModule, DModule>();
builder.Services.AddScoped<IRoleBusiness, BusinessRole>();
builder.Services.AddScoped<IDRole, DRole>();
builder.Services.AddScoped<IRoleViewBusiness, BusinessRoleView>();
builder.Services.AddScoped<IDRoleView, DRoleView>();
builder.Services.AddScoped<IUserRoleBusiness, BusinessUserRole>();
builder.Services.AddScoped<IDUserRol, DUserRol>();
builder.Services.AddScoped<IViewBusiness, BusinessView>();
builder.Services.AddScoped<IDView, DView>();
builder.Services.AddScoped<ICountryBusiness, BusinessCountry>();
builder.Services.AddScoped<IDCountry, DCountry>();
builder.Services.AddScoped<IContinentBusiness, BusinessContinent>();
builder.Services.AddScoped<IDContinent, DContinent>();
builder.Services.AddScoped<ICityBusiness, BusinessCity>();
builder.Services.AddScoped<IDCity, DCity>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowSpecificOrigin");
    app.UseSwagger();
    app.UseSwaggerUI();
}
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
