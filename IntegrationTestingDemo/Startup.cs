using IntegrationTestingDemo.App.Query;
using IntegrationTestingDemo.Core.Contracts.Repository;
using IntegrationTestingDemo.Infra.Respository;
using IntegrationTestingDemo.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace IntegrationTestingDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(GetAllEmployee).Assembly));
            services.AddDbContext<EmployeeContext>(x => x.UseInMemoryDatabase("Employee.db"));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {

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

        }
    }
}
