using crud_api.Data;
using crud_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_api.Controllers
{
   
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        private readonly PersonApiDbContext dbContext;
        public UserController(PersonApiDbContext db)

        {
            dbContext = db;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(RequestUser user)
        {
            var newUser = new User()
            {
                user_Id = new Guid(),
                user_Name = user.user_Name,
                user_Password = user.user_Password,
            };

            await dbContext.tbl_User.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return Ok(newUser);
        }

        [HttpGet]
        public async Task<IActionResult> CheckUser([FromQuery]RequestUser user)
        {
           
            bool isUserExists = await dbContext.tbl_User.AnyAsync(u => u.user_Name == user.user_Name
            && u.user_Password == user.user_Password);
            if (isUserExists)
            {
                return Ok("User is valid");
            }
            else
            {
                return NotFound();
            }

        }
    }
}
