
using Library.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetSection("Config").Bind(new Config());


DataAccessLayer.DBTools.DBConfig.ConnectionString = Config.ConnectionString;


builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
