using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly log4net.ILog s_logger = log4net.LogManager.GetLogger(typeof(ValuesController));

        private readonly IService m_service = null;

        public ValuesController(IService service)
        {
            m_service = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            ActionResult<IEnumerable<string>> retVal = new string[] { };
            try
            {
                retVal = m_service.GetData();
            }
            catch (Exception ex)
            {
                s_logger.Error(ex);
                retVal = StatusCode(StatusCodes.Status500InternalServerError);
            }
            return retVal;
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
