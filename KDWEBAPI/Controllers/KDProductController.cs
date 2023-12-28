using KDWEBAPI.DBHUBContext;
using KDWEBAPI.Models;
using KDWEBAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KDWEBAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KDProductController : ControllerBase
    {
        private readonly IBaseRepository<KDProduct> _productRepository;

        public KDProductController(IBaseRepository<KDProduct> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List()
        {
            var productList = await _productRepository.ListAsync();
            return Ok(productList);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert(KDProduct entity)
        {
            var product = await _productRepository.InsertAsync(entity);
            return Ok(product);
        }

        [HttpDelete("Delete")]
        public async Task<bool> Delete(KDProduct entity)
        {
            await _productRepository.DeleteAsync(entity);
            return true;
        }
    }
}
