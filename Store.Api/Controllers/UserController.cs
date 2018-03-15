using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Context.Entities;
using Store.Domain.StoreContext.Commands.Input;
using Store.Domain.StoreContext.Commands.Output;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserHandler _handler;

        public UserController(IUserRepository repository, UserHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Authorize]
        [Route("users")]
        public async Task<IEnumerable<User>> Get()
        {
            return await _repository.Get();
        }

        [HttpPost]
        [Authorize]
        [Route("signin")]
        public async Task<IActionResult> SingIn([FromBody]CreateUserCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [Route("signup")]
        public async Task<IActionResult> SignUp([FromBody]CreateUserCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(result);
        }
    }
}