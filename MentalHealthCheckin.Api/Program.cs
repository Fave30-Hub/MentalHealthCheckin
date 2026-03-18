using Microsoft.EntityFrameworkCore;
using MentalHealthCheckin.Infrastructure.Persistence;
using MentalHealthCheckin.Domain.Interfaces;
using MentalHealthCheckin.Infrastructure.Repositories;
using MentalHealthCheckin.Application.Interfaces;
using MentalHealthCheckin.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICheckInRepository, CheckInRepository>();
builder.Services.AddScoped<ICheckInService, CheckInService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:3000")    // frontend
            .AllowAnyHeader()    
            .AllowAnyMethod());  // get, post, put, delete
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
        
    // app.MapOpenApi();
}
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<LicenseMiddleware>();
app.MapControllers();

app.Run();  