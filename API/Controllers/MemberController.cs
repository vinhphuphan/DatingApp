using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetMembers() => await context.Users.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var member = await context.Users.FindAsync(id);

            return (member == null)
                ? NotFound()
                : Ok(member);
        }
    }
}
