using CLG.OperationAPI.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CLG.OperationAPI.Application.Repositories
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory, Context context)
        {
            _scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            //using (var serviceScope = _scopeFactory.CreateScope())
            //{
            //    using (var context = serviceScope.ServiceProvider.GetService<Context>())
            //    {
            //        context.Database.EnsureCreated();
            //    }
            //}

            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<Context>())
                {
                    context.Database.EnsureCreated();
                    context.Database.Migrate();

                    var xx = context.Operations.ToList();

                }
            }
        }
    }
}
