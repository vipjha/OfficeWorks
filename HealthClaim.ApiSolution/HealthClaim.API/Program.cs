using HealthClaim.API.Extensions;
using HealthClaim.API.Model;
using HealthClaim.BAL.Repository.Concrete;
using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.Logger;
using HealthClaim.Model.Dtos.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

var config = builder.Configuration;



//builder.Services.AddAppliationServices(config);
builder.Services.AddDbContext<HealthClaimDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)); // Logger forserilog add by vip.


builder.Services.Configure<MailSettingsModel>(config.GetSection("MailSettings"));

builder.Services.AddIdentityServices(config);
builder.Services.AddAppliationServices(config);
builder.Services.AddSingleton<INotification, Notification>();

var app = builder.Build();

app.UseSerilogRequestLogging(); // Logger for serilog add byvip.

app.UseMiddleware<ExeceptionMiddleware>();

// Configure the HTTP request pipeline.
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
