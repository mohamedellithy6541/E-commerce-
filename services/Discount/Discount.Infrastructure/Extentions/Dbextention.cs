using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Discount.Infrastructure.Extentions
{
    public static class Dbextention
    {
        public static IHost MigrateDataBase<TContext>(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();//to read the configuration settings from the appsettings.json file
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Discount DB Migration started ");
                    ApplyMigration(config);
                    logger.LogInformation("Discount DB Migration completed");

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred while migrating the database");
                    throw ex;
                }
            }
            return host;
        }

        private static void ApplyMigration(IConfiguration config)
        {
            var retryCount = 5;
            while (retryCount > 0)
            {
                try
                {
                    using var connection = new NpgsqlConnection(
                   config.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();
                    using var command = new NpgsqlCommand()
                    {
                        Connection = connection
                    };
                    command.CommandText = "DROP TABLE IF EXISTS Coupon";
                    command.ExecuteNonQuery();
                    command.CommandText = @"CREATE TABLE Coupon(Id SERIAL PRIMARY KEY, ProductName VARCHAR(24) NOT NULL, Description TEXT, Amount INT)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('IPhone X', 'IPhone Discount', 150);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Samsung 10', 'Samsung Discount', 100);";
                    command.ExecuteNonQuery();
                    break;
                }
                catch (Exception ex)
                {
                    retryCount--;
                    if (retryCount == 0)
                    {
                        throw;
                    }
                    Thread.Sleep(2000); // Wait for 1 second before retrying
                }
               
            }
        }
    }
}
