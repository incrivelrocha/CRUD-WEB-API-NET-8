using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProvaTecnicaTPC.Models.Entities;
using System.Reflection;

namespace ProvaTecnicaTPC.Data.Context
{
    public class SQLiteDBContext : DbContext
    {
        private MyAppDBContext? _context;
        public string DbPath { get; } = "DataSource=:memory:";

        public SQLiteDBContext(DbContextOptions<SQLiteDBContext> options) : base(options) 
        {
            var connection = new SqliteConnection($"Data Source=:memory:");

            connection.Open();

            var optionsContext = new DbContextOptionsBuilder<MyAppDBContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;


            using (var context = new MyAppDBContext(optionsContext))
                context.Database.EnsureCreated();            

        }

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
