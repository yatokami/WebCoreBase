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
        public async Task<ActionResult> Post([FromBody] UsersView users)
        {
            if(users == null)
            {
                return BadRequest();
            }

            var UserModel = _mapper.Map<User>(users);
            if (!await _userRepository.SaveAsync(UserModel))
            {
                return StatusCode(500, "Save Error");
            };
            return Ok();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
