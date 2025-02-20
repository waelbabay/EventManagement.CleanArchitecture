using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;
using EventManagement.CleanArchitecture.Persistence.Repositories;

namespace EventManagement.CleanArchitecture.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("EventManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            return services;
        }
    }
}
