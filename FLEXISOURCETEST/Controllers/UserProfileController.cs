using FLEXISOURCETEST.Models;
using FLEXISOURCETEST.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FLEXISOURCETEST.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserProfileController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            try
            {
                var item = await _userService.GetUser(Id);
                Console.WriteLine(item.Name + " is Selected!");
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            try
            {
                var list = await _userService.GetAllProfile();
                Console.WriteLine(list.Count.ToString() + " Record found");

                return Ok(list);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostUser(UserProfile e)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var item = await _userService.Post(e);
                Console.WriteLine(item.Name + " is Created!");
                return Ok(item);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutUser(int Id, UserProfile e)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var item = await _userService.Put(Id,e);
                Console.WriteLine(item.Name + " is Updated!");
                return Ok(item);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
