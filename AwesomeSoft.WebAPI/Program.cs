using AwesomeSoft.DataAccess.EntityFramework.Data;
using AwesomeSoft.DataAccess.EntityFramework.Repositories;
using AwesomeSoft.DataAccess.EntityFramework.UnitOfWork;
using AwesomeSoft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region In memory database

#endregion

#region Entity Framework
// Add Database
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

builder.Services.AddTransient<IUnitOfWork, EFUnitOfWork>();

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IPeopleRepository, PeopleRepository>();
builder.Services.AddTransient<IMeetingRoomRepository, MeetingRoomRepository>();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
        .WithTitle("AwesomeSoft WebAPI")
        .WithTheme(ScalarTheme.Mars)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
        //.WithApiKeyAuthentication(keyOptions => keyOptions.Token = "apikey")
        ;

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
