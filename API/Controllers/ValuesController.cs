using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace DatingApp.API.Controllers
{
    //root how to get this contoller, attribute 
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        //              00:03:43.310 ~ 00:03:49.550  But it's recommended or the recommended approach is always to make any queries to our database because
        //  00:03:49.550 ~ 00:03:57.330  they have potential to be long running queries is to always make them asynchronous it's a very very
        //  00:03:57.360 ~ 00:04:05.770  very minimal performance hit to do so and this also makes our application instantly more scalable because
        //  00:04:05.770 ~ 00:04:11.830  when we make a request to our database and we make the method an async method then this is going to
        //  00:04:11.830 ~ 00:04:19.690  pass the database query to a different thread and it's not going to block the threads where they get
        //  00:04:19.690 ~ 00:04:22.120  request is coming in on.

        //          00:04:22.190 ~ 00:04:28.590  So what we can do is instead of saying just returning a public action result here what we can do is
        //  00:04:28.590 ~ 00:04:38.890  return public async and when we use an async method we to return to task and then we can wrap this around


        // GET api/valuessd
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);

//            00:05:16.860 ~00:05:23.610  But instead of running the entire request on one thread including going out to get our values from the

//00:05:23.610 ~00:05:32.040  database this is now passing off the request to call our database onto a different thread and then we
// 00:05:32.220 ~00:05:39.870  awaits that task to be completed but we're not blocking the request.
// 00:05:39.940 ~00:05:46.570  The threads that the request comes in on now it's pretty simple to make our synchronous code asynchronous.
// 00:05:46.690 ~00:05:51.620  And like I say it doesn't incur a significant performance hit.
// 00:05:51.790 ~00:05:59.590  So whenever you write a method that has potential to be long running and any call to a database has
// 00:05:59.590 ~00:06:01.140  that potential.


            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
//            00:07:30.260 ~00:07:37.550  and if we're using single or default stand what little of return is ever the value if it finds it or
// 00:07:37.550 ~00:07:44.540  the default value for the type of objects we're querying and in the case of value it's an object.

//00:07:44.540 ~00:07:50.070  So it's default value is no and that's what we would get back from this.

//00:07:50.080 ~00:07:52.290  However there's also another one we can use.

//           Singleordefault
            var value = await _context.Values.FindAsync(id);
            return Ok(value);
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
