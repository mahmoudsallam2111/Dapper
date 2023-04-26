using Dapper.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Dapper.DAL.Repository.product_Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration configuration;

        public ProductRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> Add(Product entity)
        {
            var sqlQuery =  "insert into Product(Name , BarCode , Description , Rate , AddedOn , ModifiedOn) values" +
                "(@Name ,@BarCode , @Description , @Rate , @AddedOn , @ModifiedOn)";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var res = await connection.ExecuteAsync(sqlQuery  , entity);
                return res;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sqlQuery ="delete from Product where Id = @Id";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var res = await connection.ExecuteAsync(sqlQuery, new { Id = id});
                return res;
            }
        }

        public async Task<IReadOnlyList<Product>> GetAll()
        {
            var sqlQuery = "select * from product";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var res = await connection.QueryAsync<Product>(sqlQuery);
                return res.ToList();
            }
        }

        public async Task<Product> GetById(int id)
        {
            var sqlQuery = "select * from product where Id = @id";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var res = await connection.QueryFirstOrDefaultAsync<Product>(sqlQuery , new { Id = id});
                return res;
            }

        }

        public async Task<int> Update(Product entity)
        {
            var sqlQuery = "UPDATE Product SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var res = await connection.ExecuteAsync(sqlQuery,entity);
                return res;
            }
        }
    }
}
