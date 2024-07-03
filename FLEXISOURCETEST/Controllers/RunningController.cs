using FLEXISOURCETEST.Models;
using FLEXISOURCETEST.Services.RunningService;
using FLEXISOURCETEST.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLEXISOURCETEST.Controllers
{
    [Route("api/running")]
    [ApiController]
    public class RunningController : ControllerBase
    {
        private readonly IRunningService _runningService;
        public RunningController(IRunningService runningService)
        {
            _runningService = runningService;
        }

        [HttpPost]
        public async Task<IActionResult> PostRunning(int UserId, RunningActivity e)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var item = await _runningService.PostRunning(UserId, e);
                return Ok(item);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
