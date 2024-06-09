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
    public class KDPointTableController : ControllerBase
    {
        private readonly IBaseRepository<KDPointTable> _PointTableRepository;

        public KDPointTableController(IBaseRepository<KDPointTable> PointTableRepository)
        {
            _PointTableRepository = PointTableRepository;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List()
        {
            var PointTableList = await _PointTableRepository.ListAsync();
            return Ok(PointTableList);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int PointTableId)
        {
            var PointTable = await _PointTableRepository.GetByIdAsync(PointTableId);

            if (PointTable == null)
            {
                return NotFound();
            }
            return Ok(PointTable);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert(KDPointTable entity)
        {
            var PointTable = await _PointTableRepository.InsertAsync(entity);
            return Ok(PointTable);
        }

        [HttpDelete("Delete")]
        public async Task<bool> Delete(KDPointTable entity)
        {
            await _PointTableRepository.DeleteAsync(entity);
            return true;
        }
    }
}
