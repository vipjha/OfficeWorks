using Microsoft.OpenApi.Models;
using TourProgram.BAL.Repository.Concrete;
using TourProgram.BAL.Repository.Interface;
using TourProgram.Utility.PdfUtility;

namespace TourProgram.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddAppliationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IEmpTourPlanRepository, EmpTourPlanRepository>();
            services.AddScoped<ITentativeTravelPlanRepository, TentativeTravelPlanRepository>();
            services.AddScoped<IActualTravelPlanRepository, ActualTravelPlanRepository>();
            services.AddScoped<ICommanRepository, CommanRepository>();
            services.AddScoped<ITourListingRepository, TourListingRepository>();
            services.AddScoped<ITourStatusRepository, TourStatusRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<PDFGenerator>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IBulkApprovalRepository, BulkApprovalRepository>();



            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "DFCCIL Tour Programm", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                     Type=ReferenceType.SecurityScheme,
                                       Id="Bearer"
                                }
                              },
                            new string[]{}
                    }
                });
            });
            //Cors Named Policy
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://uat.tourprogram.cetpainfotech.com", "https://localhost:7072")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            return services;
        }
    }
}
