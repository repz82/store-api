using Microsoft.AspNetCore.Mvc;
using Store.Domain.Context.Entities;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Shared.Commands;
using System.Collections.Generic;

namespace Store.Api.Controllers
{
    [Produces("application/json")]
    [Route("user")]
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
        //[ResponseCache(Duration = 15)]
        public IEnumerable<User> Get()
        {
            return _repository.Get();
        }
    }
}