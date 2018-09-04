using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreApi.Tools;
using CoreApi.DTO;
using CoreApi.Models;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var LogLevel= ConfigHelper.GetSection<LogLevel>("Logging:LogLevel");
                return LogLevel.Default.ToJsonResult();
            }
            catch (Exception ex)
            {
                return ResultHelper.ToExceptionResult(300,ex.Message);
            }
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
