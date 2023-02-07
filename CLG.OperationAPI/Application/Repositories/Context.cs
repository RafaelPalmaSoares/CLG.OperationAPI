using CLG.OperationAPI.Application.Mappings;
using CLG.OperationAPI.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CLG.OperationAPI.Application.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OperationMap());
        }
    }
}
