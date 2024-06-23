using XPBanking.API.Data;
using XPBanking.API.Data.Interface;
using XPBanking.API.Services;
using XPBanking.API.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IConsultInvestimentRepository, ConsultInvestimentRepository>();
builder.Services.AddScoped<IConsultInvestmentService, ConsultInvestmentService>();
builder.Services.AddScoped<ISendEmailService, SendEmailService>();

builder.Services.AddDbContext<XPBankingContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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
