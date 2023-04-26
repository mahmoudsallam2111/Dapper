using Dapper.Core.Dtos;
using Dapper.Core.Managers.Product;
using Dapper.DAL.Models;
using Dapper.DAL.Repository.product_Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DaPPer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;

        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await productManager.GetAll();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await productManager.GetById(id);
            return Ok(res);
        }


        [HttpPost]
        public async Task<IActionResult> Add(writeProductDto product)
        {
            var res = await productManager.Add(product);
            return (res == 1) ? CreatedAtAction(actionName: "GetById", routeValues: new { id = product.Id },
                new { message = "item added successfully" } ): BadRequest("Invalid Opreation");
        }



        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var res = await productManager.Update(updateProductDto);

            return (res == 1) ? Ok("Product Upadted Successfultly") : BadRequest("Invalid result value");


        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await productManager.Delete(id);

            return (res == 1) ? Ok("Product Delete Successfultly") : BadRequest("Invalid result value");


        }



    }
}
