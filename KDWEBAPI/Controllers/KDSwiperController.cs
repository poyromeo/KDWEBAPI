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
    public class KDSwiperController : ControllerBase
    {
        private readonly IBaseRepository<KDSwiper> _swiperRepository;

        public KDSwiperController(IBaseRepository<KDSwiper> swiperRepository)
        {
            _swiperRepository = swiperRepository;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List()
        {
            var swiperList = await _swiperRepository.ListAsync();
            return Ok(swiperList);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int swiperId)
        {
            var swiper = await _swiperRepository.GetByIdAsync(swiperId);

            if (swiper == null)
            {
                return NotFound();
            }
            return Ok(swiper);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert(KDSwiper entity)
        {
            var swiper = await _swiperRepository.InsertAsync(entity);
            return Ok(swiper);
        }

        [HttpDelete("Delete")]
        public async Task<bool> Delete(KDSwiper entity)
        {
            await _swiperRepository.DeleteAsync(entity);
            return true;
        }
    }
}
