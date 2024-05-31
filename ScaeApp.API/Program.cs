using ScaeApp.API.Extension;
using ScaeApp.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(map =>
{
    map.LowercaseUrls = true;
});
builder.Services.AddSwaggerGen();

//Política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapper(typeof(ProfileMap));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();

public partial class Program { }