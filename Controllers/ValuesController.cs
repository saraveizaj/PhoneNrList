using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneNrLists.Data;
using PhoneNrLists.Phone;

namespace PhoneNrLists.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private ApplicationDbContext _ctx;
        public ValuesController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

               
        // GET api/values
        [HttpGet]
        public IActionResult Get() => Ok(new GetAll(_ctx).Do());


        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(new Get(_ctx).Do(id));

        // POST api/values
        [HttpPost]
        public IActionResult Create(Create.Request request) => Ok(new Create(_ctx).Do(request));

        // PUT api/values/5
        [HttpPut]
        public IActionResult Update(Update.Request request) => Ok(new Update(_ctx).Do(request));
        

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(new Delete(_ctx).Do(id));
        
    }
}
