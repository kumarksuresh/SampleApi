using Microsoft.EntityFrameworkCore;
using SampleApi.Data;

const string INSURED_DATA_CONNECTION_KEY = "InsuredData";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<InsuredInfoContext>(optns => optns.UseSqlServer(builder.Configuration.GetConnectionString(INSURED_DATA_CONNECTION_KEY)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
