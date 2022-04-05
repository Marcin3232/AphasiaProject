
using AphasiaProject.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaProject.Controllers.MainPanel
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppMainPanelController: ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AppMainPanelController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;

        }
        [HttpGet]
        [Route("{therapistId}")]
        public async Task<IActionResult> Users(int therapistId)
        {
            using (var context = _applicationDbContext)
            {
               return Ok(context.Users);
            }
            
        }
    }
}
