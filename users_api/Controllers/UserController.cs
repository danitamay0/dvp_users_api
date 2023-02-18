using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using users_api.Data;
using users_api.Models;
using users_api.Sources;

namespace users_api.ControllerBase
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly DoubleVPartnersDbContext dbContext;

        public UserController(DoubleVPartnersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<User> GetUsers()
        {
            //return new { tokent = "yes" };
            DataTable tUser = DBData.Listar("get_users");
            string jsonUser = JsonConvert.SerializeObject(tUser);

            return JsonConvert.DeserializeObject<List<User>>(jsonUser);
            

        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public ActionResult<User> GetUserById(string id)
        {
            //return new { tokent = "yes" };
            var userDb =  dbContext.Users.Find(id);

            if (userDb is null)
            {
                return NotFound();
            }
            return userDb;

        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> SaveUser(AddUserRequest user)
        {
            var userDb = await dbContext.Users.Where(x => x.user == user.user).FirstOrDefaultAsync();
            if (userDb != null)
            {
                return Problem("username already exist");
            }
            var newUser = new User() { user = user.user, password = user.password };

            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof (GetUserById), new { id = newUser.id}, newUser); 
        }
    }
}
