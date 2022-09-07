using Microsoft.AspNetCore.Mvc;
using WiseCRM.Models;

namespace WiseCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly ColorContext _context;

        public ColorController(ColorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Color>> Get()
        {
            return _context.Colors;
        }
    }
}
