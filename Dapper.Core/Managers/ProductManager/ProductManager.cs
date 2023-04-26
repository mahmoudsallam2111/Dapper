using AutoMapper;
using Dapper.Core.Dtos;
using Dapper.DAL.Models;
using Dapper.DAL.Repository.product_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dapper.Core.Managers.Product
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductManager(IProductRepository productRepository , IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<int> Add(writeProductDto writeProductDto)
        {
            var productToAdd = mapper.Map<DAL.Models.Product>(writeProductDto);
            var res = await productRepository.Add(productToAdd);
            return res;
        }

        public async Task<int> Delete(int id)
        {
          return await productRepository.Delete(id);
        }

        public async Task<IReadOnlyList<ReadproductDto>> GetAll()
        {
            var productlistfromDb = await productRepository.GetAll();
            return mapper.Map<IReadOnlyList<ReadproductDto>>(productlistfromDb);   
        }

        public async Task<ReadproductDto> GetById(int id)
        {
            var productfromDb = await productRepository.GetById(id);
            return mapper.Map<ReadproductDto>(productfromDb);

        }

        public async Task<int> Update(UpdateProductDto updateProductDto)
        {
            var producttoUpdate = mapper.Map<DAL.Models.Product>(updateProductDto);
             return  await productRepository.Update(producttoUpdate);

        }
    }
}
