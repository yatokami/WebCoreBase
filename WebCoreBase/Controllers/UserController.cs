using AutoMapper;
using EFCore.Interfaces;
using EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCoreBase.ViewModel;

namespace WebCoreBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersView>>> Get()
        {
            var user =  await _userRepository.GetListAsync();
            var users = _mapper.Map<List<UsersView>>(user);
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<UsersView>> Get(int id)
        {
            var user = await _userRepository.GetInfoAsync(id);
            if(user == null)
            {
                return Ok();
            }

            var users = _mapper.Map<UsersView>(user);
            return Ok(users);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserViewPost users)
        {
            if(users == null)
            {
                return BadRequest();
            }

            var UserModel = _mapper.Map<User>(users);
            _userRepository.Save(UserModel);
            if (!await _userRepository.SaveChangesAsync())
            {
                return StatusCode(500, "Save Error");
            };
            var user = _mapper.Map<UsersView>(UserModel);
            return CreatedAtRoute("Get", new { id = user.Id }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserViewPost users)
        {
            if (users == null || id == 0)
            {
                return BadRequest();
            }

            var userInfo = await _userRepository.GetInfoAsync(id);

            var UserModel = _mapper.Map(users, userInfo);
            if (!await _userRepository.SaveChangesAsync())
            {
                return StatusCode(500, "Save Error");
            };
            var user = _mapper.Map<UsersView>(UserModel);
            return CreatedAtRoute("Get", new { id = user.Id }, user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userInfo = await _userRepository.GetInfoAsync(id);
            if (userInfo == null)
            {
                return BadRequest();
            }
            _userRepository.Delete(userInfo);
            if (!await _userRepository.SaveChangesAsync())
            {
                return StatusCode(500, "Save Error");
            };

            return NoContent();
        }
    }
}
