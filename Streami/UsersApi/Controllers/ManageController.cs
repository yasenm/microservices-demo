using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UsersApi.Services;
using UsersApi.ViewModels;

namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private readonly IUserService userService;

        public ManageController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            var user = this.userService.Get<UserProfileViewModel>(id);
            return user == null ? this.Ok("No such user") : this.Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(AddOrUpdateUserViewModel model)
        {
            var result = await this.userService.AddOrUpdate(model);

            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest("Model incorect");
        }
    }
}
