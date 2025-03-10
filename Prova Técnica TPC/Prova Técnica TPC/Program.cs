using Microsoft.EntityFrameworkCore;
using ProvaTecnicaTPC.Data.Context;
using ProvaTecnicaTPC.Data.MapperProfilers;
using ProvaTecnicaTPC.Repositories.Interfaces;
using ProvaTecnicaTPC.Repositories.Repository;
using ProvaTecnicaTPC.Services.Usuarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CONEXÃO OFICIAL MYSQL / InMemory / SQLite
var connectionStringMySQl = builder.Configuration.GetConnectionString("ConnectionMySQL");

builder.Services.AddDbContext<MyAppDBContext>(options =>
{
    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
    {
        //options.UseSqlite(builder.Configuration.GetConnectionString("ConnectionSQLite"));
        options.UseInMemoryDatabase("InMemoryDb");
    }
    else
    {
        options.UseMySql(
                connectionStringMySQl,
                ServerVersion.Parse("10.4.22-MariaDB")
             );
    }
});


builder.Services.AddAutoMapper(typeof(EntidadesToDTOsProfile));

builder.Services.AddTransient<IUsuariosService, UsuariosService>();
builder.Services.AddTransient<ITarefasService, TarefasService>();

builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddTransient<ITarefasRepository, TarefasRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

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
