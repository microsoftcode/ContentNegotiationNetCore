using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
			List<Employee> employees = new List<Employee>();	
			employees.Add(new Employee { Id = 1, Name = "AmitPatil", Gender = "Male", Dept = "EmergingTechnologies" });
			employees.Add(new Employee { Id = 2, Name = "TomHanks", Gender = "Male", Dept = "MovieMaking" });
			employees.Add(new Employee { Id = 3, Name = "SaraLin", Gender = "Female", Dept = "UserDesign" });
			employees.Add(new Employee { Id = 4, Name = "RahulRoy", Gender = "Male", Dept = "DevOps" });
			return Ok(employees);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }	
	

	}

	
  
}
