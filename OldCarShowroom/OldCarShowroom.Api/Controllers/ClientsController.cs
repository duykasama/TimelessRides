using Microsoft.AspNetCore.Mvc;
using OldCarShowroom.Service.Models;

namespace OldCarShowroom.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {

        private readonly OldCarShowroomContext _context;
        public ClientsController(OldCarShowroomContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_context.Clients);
        }
    }
}
