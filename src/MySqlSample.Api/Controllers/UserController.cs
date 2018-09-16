using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlSample.Api.Controllers.Responses;
using MySqlSample.Api.Data.Mapping;
using MySqlSample.Api.Data.Repository;
using MySqlSample.Api.Ioc;
using MySqlSample.Api.RequestBodies;

namespace MySqlSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var repository = ServiceLocator.Current.GetInstance<IRepository<User>>();
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return ServiceLocator.Current.GetInstance<IRepository<User>>().GetById(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserRequest user)
        {
            var mappedUser = new User(user.Name, user.Email);
            var id = ServiceLocator.Current.GetInstance<IRepository<User>>().Insert(mappedUser);
            return Created(string.Empty, new CreatedResponse(id));
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody] UserRequest user)
        {
            var repository = ServiceLocator.Current.GetInstance<IRepository<User>>();
            var databaseUser = repository.GetById(id);
            databaseUser.Email = user.Email;
            databaseUser.Name = user.Name;
            repository.Update(databaseUser);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var repository = ServiceLocator.Current.GetInstance<IRepository<User>>();
            var databaseUser = repository.GetById(id);
            repository.Delete(databaseUser);
        }
    }
}
