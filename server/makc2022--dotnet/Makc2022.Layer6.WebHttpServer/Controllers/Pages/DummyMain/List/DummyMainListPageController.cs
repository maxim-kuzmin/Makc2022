// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Makc2022.Layer6.WebHttpServer.Controllers.Pages.DummyMain.List
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyMainListPageController : ControllerBase
    {
        // GET: api/<DummyMainListPageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DummyMainListPageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DummyMainListPageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DummyMainListPageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DummyMainListPageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
