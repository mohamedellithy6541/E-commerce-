using Dapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;     
        }
        public async Task<Coupon> GetDiscount(string productName)
        {
           await  using var connectionString = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connectionString.
                QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", 
                new { ProductName = productName });
            if (coupon == null)
            {
                return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
            }
            return coupon; // return coupon if found, otherwise return a default coupon indicating no discount
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            await using var connectionString = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connectionString.ExecuteAsync(
                " INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            return affected > 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            await using var connectionString = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var deleted = await connectionString.ExecuteAsync(
                " DELETE FROM Coupon WHERE ProductName = @ProductName",
                new { ProductName = productName });
            return deleted > 0;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            await using var connectionString = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connectionString.ExecuteAsync(
                " UPDATE Coupon SET ProductName = @ProductName, " +
                "Description = @Description," +
                " Amount = @Amount " +
                "WHERE Id = @Id",

                new { 
                    ProductName = coupon.ProductName, 
                    Description = coupon.Description, 
                    Amount = coupon.Amount,
                    Id = coupon.Id });

            return affected > 0;

        }
    }
}
