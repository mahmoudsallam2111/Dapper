using Dapper.DAL.Models;
using Dapper.DAL.Repository.Generic_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.DAL.Repository.product_Repository
{
   public interface IProductRepository:IGenericRepository<Product>
    {
    }
}
