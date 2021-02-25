using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/xml")]
    public class oldFacultyController : ControllerBase
    {
        IFacultyRepository _repository;
        public oldFacultyController(IFacultyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        // GET: api/Faculty
        public IEnumerable<Faculty> Get()
        {
            return _repository.AllItems;
        }

        [HttpGet("{id}")]
        // GET: api/Faculty/41495988-76D0-47C7-97B9-31E759F16485
        public async Task<Faculty> Get(Guid id)
        {
            return await _repository.GetItemAsync(id);
        }
        [HttpPost]
        // POST: api/Faculty
        public async Task<ActionResult> Post(Faculty faculty)
        {
            if (await _repository.AddItemAsync(faculty) > 0)
            {
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        // PUT:api/Faculty
        public async Task<ActionResult> Put(Faculty faculty)
        {
            if (await _repository.UpdateItemAsync(faculty))
            {
                return new StatusCodeResult(StatusCodes.Status202Accepted);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id}")]
        // DELETE: api/Faculty/41495988-76D0-47C7-97B9-31E759F16485
        public async Task<ActionResult> Delete(Guid id)
        {
            if (await _repository.DeleteItem(id))
            {
                return new StatusCodeResult(StatusCodes.Status202Accepted);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
