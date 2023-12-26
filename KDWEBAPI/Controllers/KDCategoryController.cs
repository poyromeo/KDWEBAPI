using KDWEBAPI.DBHUBContext;
using KDWEBAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KDWEBAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KDCategoryController : ControllerBase
    {
        private readonly HBContext _context;
        public KDCategoryController(HBContext context)
        {
            _context = context;
        }

        [HttpGet("List")]
        public ActionResult<IEnumerable<KDCategory>> List()
        {
            return _context.KDCategory.ToList();
        }

        [HttpGet("GetById")]
        public ActionResult<KDCategory> GetById(int id)
        {
            var category = _context.KDCategory.FirstOrDefault(r => r.CategoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost("Insert")]
        public ActionResult<KDCategory> Insert(KDCategory product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _context.KDCategory.Add(product);
            _context.SaveChanges();

            return product;
        }

        [HttpDelete("Delete")]
        public ActionResult<KDCategory> DeleteProduct(int id)
        {
            var category = _context.KDCategory.FirstOrDefault(r => r.CategoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            _context.KDCategory.Remove(category);
            _context.SaveChanges();

            return category;
        }
    }
}
