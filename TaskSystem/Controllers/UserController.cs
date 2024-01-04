using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> SearchAllUsers()
        {
            List<UserModel> users = await _userRepository.SearchAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> SearchPerId(int id)
        {
            UserModel user = await _userRepository.SearchPerId(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Add([FromBody] UserModel user)
        {
            UserModel add = await _userRepository.Add(user);
            return Ok(add);
        }

        [HttpPut]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel user, int id)
        {
            UserModel update = await _userRepository.Update(user, id);
            return Ok(update);
        }
    }
}
