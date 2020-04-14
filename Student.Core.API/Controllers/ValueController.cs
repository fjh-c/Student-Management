using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Student.Core.API.Controllers
{
    /// <summary>
    /// 通过api/values
    /// </summary>
    [Description("通过api/values")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        /// <summary>
        /// 默认获取
        /// </summary>
        /// <returns></returns>
        [Description("默认获取")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "this is swagger demo";
        }

        // POST api/values
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// 通过 Id 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// 根据 Id 删除
        /// </summary>
        /// <param name="id">主键</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}