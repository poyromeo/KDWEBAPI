using KDWEBAPI.DBHUBContext;
using KDWEBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KDWEBAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KDProductController : ControllerBase
    {
        private readonly HBContext _context;
        public KDProductController(HBContext context)
        {
            _context = context;
        }

        [HttpGet("List")]
        public ActionResult<IEnumerable<KDProduct>> List()
        {
            List<KDProduct> productList = _context.KDProduct.ToList();
            List<int?> categoryIdList = productList.Select(r => r.CategoryID).ToList();
            List<KDCategory> categoryList = _context.KDCategory.Where(r => categoryIdList.Contains(r.CategoryID)).ToList();

            foreach (KDProduct product in productList)
            {
                var category = categoryList.FirstOrDefault(r => r.CategoryID == product.CategoryID);

                if (category != null)
                {
                    product.CategoryName = category.CategoryName;
                }
            }

            return productList;
        }

        [HttpGet("GetById")]
        public ActionResult<KDProduct> GetById(int productId)
        {
            var product = _context.KDProduct.FirstOrDefault(r => r.ProductID == productId);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost("Insert")]
        public ActionResult<KDProduct> Insert(KDProduct product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _context.KDProduct.Add(product);
            _context.SaveChanges();

            return product;
        }

        [HttpDelete("Delete")]
        public ActionResult<KDProduct> DeleteProduct(int productId)
        {
            var product = _context.KDProduct.FirstOrDefault(r => r.ProductID == productId);

            if (product == null)
            {
                return NotFound();
            }

            _context.KDProduct.Remove(product);
            _context.SaveChanges();

            return product;
        }
    }
}
