using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tasks.Data;

namespace Tasks.Tests;

public class TasksWebAppFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Encontrar o registro do DbContextOptions<AppDbContext>
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

            // Se encontrado, remover o registro existente
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Adicionar um novo DbContext com SQLite em memória
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("DataSource = InMemoryTest; Mode = Memory; Cache = Shared"));

            // Criar o provedor de banco de dados em memória
            var sp = services.BuildServiceProvider();

            // Criar o escopo para garantir que o banco de dados seja criado
            // using é necessário para garantir que o escopo seja descartado após o uso
            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        });
    }
}