using Dapper.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Managers.Product
{
   public interface IProductManager
    {
        Task<IReadOnlyList<ReadproductDto>> GetAll();
        Task<ReadproductDto> GetById(int id);

        Task<int> Add(writeProductDto writeProductDto);

        Task<int> Update(UpdateProductDto entity);
        Task<int> Delete(int id);
    }
}
