using Microsoft.Extensions.Options;
using MongoNet6NOGIT.Interfaces;
using MongoNet6NOGIT.Models;
using MongoNet6NOGIT.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<UsersDatabaseSettings>(builder.Configuration.GetSection(nameof(UsersDatabaseSettings)));

builder.Services.AddSingleton<IUsersDatabaseSetting>(sp =>
       sp.GetRequiredService<IOptions<UsersDatabaseSettings>>().Value);

builder.Services.AddSingleton<UserService>();

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.UseMemberCasing());

// Add services to the container.

builder.Services.AddControllers();
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
