using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using prjRESTful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prjRESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private NorthwindDbContext _context;

        public CustomerController(NorthwindDbContext context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var customers = _context.Customers.ToList();
            yield return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // GET api/<CustomerController>/{id}
        [HttpGet("{id}")]
        public string Get(string id)
        {
            var customer = _context.Customers.FirstOrDefault(m => m.CustomerId == id);
            return JsonConvert.SerializeObject(customer, Formatting.Indented);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public string Post([FromBody] Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return "OK";
            }
            catch(Exception ex)
            {
                return ex.StackTrace;
            }
        }

        // PUT api/<CustomerController>/{id}
        [HttpPut("{id}")]
        public string Put(string id, [FromBody] Customer customer)
        {
            try
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return "OK";
            }
            catch(Exception ex)
            {
                return ex.StackTrace;
            }
        }

        // DELETE api/<CustomerController>/{id}
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(m => m.CustomerId == id);
                _context.Remove(customer);
                _context.SaveChanges();
                return "OK";
            }
            catch(Exception ex)
            {
                return ex.StackTrace;
            }
        }
    }
}
