using Microsoft.EntityFrameworkCore;
using ProvaTecnicaTPC.Models.Entities;
using System.Reflection;

namespace ProvaTecnicaTPC.Data.Context
{
    public class MyAppDBContext : DbContext
    {
        public MyAppDBContext(DbContextOptions<MyAppDBContext> options) : base(options) { }

        public DbSet<StatusEntity> Status { get; set; }
        public DbSet<TarefasEntity> Tarefas { get; set; }
        public DbSet<UsuariosEntity> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(builder);
        }

    }
}
