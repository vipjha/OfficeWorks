using Microsoft.EntityFrameworkCore;
using Serilog;
using TourProgram.API.Extensions;
using TourProgram.API.Model;
using TourProgram.DAL;
using TourProgram.Logger;
using TourProgram.Model.Dtos.Notification;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

//builder.Services.AddAppliationServices(config);
builder.Services.AddDbContext<TourProgramDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)); // Logger forserilog add by vip.


// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<MailSettingsModel>(config.GetSection("MailSettings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityServices(config);
builder.Services.AddAppliationServices(config);


var app = builder.Build();

//app.UseSerilogRequestLogging(); // Logger for serilog add byvip.

app.UseMiddleware<ExeceptionMiddleware>();

/*// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/


if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<SwaggerBasicAuthMiddleware>();

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseMiddleware<SwaggerBasicAuthMiddleware>();

    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
