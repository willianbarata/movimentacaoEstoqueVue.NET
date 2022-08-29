using Microsoft.EntityFrameworkCore;
using MovEstqZdzCodeAPI.Models.Context;
using MovEstqZdzCodeAPI.Service;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration["MySqlConnection:MysqlConnectionString"];

builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(
        connection, new MySqlServerVersion(new
            Version(5, 7, 36))));

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<EmpPesService>();
builder.Services.AddScoped<MovEstqService>();
builder.Services.AddScoped<ItemMovEstqService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
