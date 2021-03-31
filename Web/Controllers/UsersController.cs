using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces.Services;
using AutoMapper;
using Web.Models.User;

namespace Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICrudUserService _crudUserService;
        private readonly IMapper _mapper;

        public UsersController(ICrudUserService service, IMapper mapper)
        {
            _crudUserService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<User> users = await _crudUserService.GetAll();
            var userModels =
                _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);
            return Ok(userModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            User User = await _crudUserService.GetById(id);
            UserModel userModel = _mapper.Map<User, UserModel>(User);
            return Ok(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserModel userModel)
        {
            User UserToCreate = _mapper.Map<CreateUserModel, User>(userModel);
            User NewUser = await _crudUserService.Create(UserToCreate);
            var UserForModel = _mapper.Map<User, UserModel>(NewUser);
            return Ok(UserForModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateUserModel user, int id)
        {
            User userToUpdate = _mapper.Map<UpdateUserModel, User>(user);
            userToUpdate.Id = id;
            User UpdateUser = await _crudUserService.Update(userToUpdate);
            var userModel = _mapper.Map<User, UserModel>(UpdateUser);
            return Ok(userModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _crudUserService.Delete(new User { Id = id });
            return Ok();
        }
    }
}
