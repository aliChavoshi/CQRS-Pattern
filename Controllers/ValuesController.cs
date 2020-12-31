using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_MediatR.Commands;
using CQRS_MediatR.Notifications;
using CQRS_MediatR.Queries;
using MediatR;

namespace CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await _mediator.Send(request: new GetValuesQuery.Query());
        }

        // GET api/values
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /*// POST api/values
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            await _mediator.Send(new AddValueCommand.Command
            {
                Value = value
            });
        }*/
        
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            await _mediator.Send(new AddValueCommand.Command
            {
                Value = value
            });

            await _mediator.Publish(new ValueAddedNotification { Value = value });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
