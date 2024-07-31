using InvestmentPortfolio.Application.AutoMapper;
using InvestmentPortfolio.Application.UseCases.UsuarioUseCases;
using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infraestructure.Data;
using InvestmentPortfolio.Infraestructure.Repositories;
using InvestmentPortfolio.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

NativeInjector.RegisterServices(builder.Services);

builder.Services.AddAutoMapper(typeof(AutoMapperSetup));

builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddCors(options => options.AddPolicy(name: "FrontendUI",
    policy =>
    {
        policy.WithOrigins("https://localhost:44320").AllowAnyMethod().AllowAnyHeader();
    }
));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendUI");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
