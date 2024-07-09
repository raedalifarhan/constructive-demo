using API.Data;
using API.Entities;
using API.RequestHelpers;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class AppServicesExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services,
                IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt => opt
                .UseSqlServer(config.GetConnectionString("app-conn")));

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(AutoMappingProfiles).Assembly);

            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
            services.AddScoped(typeof(IDepartmentService), typeof(DepartmentService));

            services.AddCors(opt =>
            {
                opt.AddPolicy("Access-Control-Allow-Origin", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200");
                });
            });

            return services;
        }
    }
}