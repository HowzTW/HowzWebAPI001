using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HowzWebAPI001.Models;
using Google.Cloud.Datastore.V1;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HowzWebAPI001.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        //GET api/employee/get/
        [HttpGet("[action]")]
        public IEnumerable<Employee> Get()
        {
            List<Employee> EmployeeList = new List<Employee>();
            DatastoreDb Db = GoogleCloudDatastore.CreateDb();

            // 查詢現有貝工
            Query QueryInstance = new Query("Employee");
            var AllEmployee = Db.RunQueryLazily(QueryInstance);
            foreach (Entity EntityInstance in AllEmployee.ToList())
            {
                EmployeeList.Add(new Employee(EntityInstance));
            }

            return EmployeeList;
        }

        // GET api/employee/get/5
        [HttpGet("[action]/{id}")]
        public Employee Get(long id)
        {
            DatastoreDb db = GoogleCloudDatastore.CreateDb();

            Entity employeeEntity = db.Lookup(GoogleCloudDatastore.ToKey(id, "Employee"));
            if (employeeEntity != null)
            {
                return new Employee(employeeEntity);
            }
            else
            {
                return null;
            }
        }

        // POST api/employee/add/
        [HttpPost("[action]")]
        public IActionResult Add([FromBody]Employee NewEmployee)
        {
            NewEmployee.Password = DateTime.Now.ToString();
            return Created("http://localhost:5000/api/test/get/", NewEmployee);


            //return CreatedAtRoute("api/employee/get", new { id = NewEmployee.Id });
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
