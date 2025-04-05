using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyChatRooms.API.Data;
using MyChatRooms.API.Data.Models;

namespace MyChatRooms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //TODO Separate GroupCreation logic in a service layer
    public class GroupsController : ControllerBase
    {
        private AppDbContext context;

        //TODO Remove dependencies and create a seperate reusable service for retrieving user information
        private readonly HttpContext httpContext;
        private readonly UserManager<IdentityUser> userManager;

        public GroupsController(AppDbContext appDbContext, HttpContext httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            this.context = appDbContext;
            this.httpContext = httpContextAccessor;
            this.userManager = userManager;
        }
        [HttpPost("CreateGroup")]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupDto groupDto)
        {
            var user = await userManager.GetUserAsync(httpContext.User);

            if (user == null || String.IsNullOrEmpty(user.UserName))
            {
                return BadRequest("user is non existent");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("invalid group parameters");
            }

            Group newGroup = new Group(groupDto.Name);
            newGroup.UserGroups.Add(new UserGroups
            {
                GroupId = newGroup.Id,
                UserId = user.Id,
            });
            //TODO handle database operations in a factory that will be injected in the controller
            await context.Groups.AddAsync(newGroup);
            await context.SaveChangesAsync();

            return Ok();
        }
    }

    public class CreateGroupDto
    {
        [Required]
        public string Name { get; set; }
    }
}
