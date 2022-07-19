// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.AspNetCore.Mvc;

namespace Makc2022.Layer6.Sql.WebHttpServer.Controllers.Pages.DummyMain.Item
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyMainItemPageController : ControllerBase
    {
        // GET: api/<DummyMainItemPageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DummyMainItemPageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DummyMainItemPageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DummyMainItemPageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DummyMainItemPageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
