using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Messaging;
using MediaApi.Infra;
using MongoDB.Driver;

namespace MediaApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MongoContext ctx;

        public ValuesController(MongoContext ctx)
        {
            this.ctx = ctx;
            this.ctx.Videos.InsertOne(
                new Model.Video
                {
                    Content = new byte[] { 1, 3, 4, 5 },
                    Title = "ADAS",
                    UpdateDate = DateTime.UtcNow
                });
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = this.ctx.Videos.Find(x => true).ToList();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
