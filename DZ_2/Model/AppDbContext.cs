using Microsoft.EntityFrameworkCore;

namespace DZ_2.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<FarmVehicleFleet> Veciles { get; set;}

        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 1. получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // 2. инициализируем саму строку подключения
            string connectionString = configuration.GetConnectionString("CloudDbConnection");
            // 3. устанавливаем для контекста строку подключения
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
