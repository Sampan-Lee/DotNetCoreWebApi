using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Models;
using CoreApi.Tools;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly DBContext dBContext;
        public TestController(DBContext _dBContext) {
            dBContext = _dBContext;
        }
        // GET: api/<controller>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                LogHelper.LogInformation("aaa");
                LogHelper.LogDebug("aaa");
                LogHelper.LogError("aaa");
                var user = dBContext.User.ToList();
                return user.ToJsonResult();
            }
            catch (Exception ex)
            {
                return ResultHelper.ToExceptionResult(300, ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
