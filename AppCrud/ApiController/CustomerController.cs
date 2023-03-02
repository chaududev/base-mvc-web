using AppCrud.Models;
using AppCrud.Service.CustomersService;
using AppCrud.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppCrud.ApiController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerService customerService;
        public CustomerController(ICustomerService _customerService)
        {
            this.customerService = _customerService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customerService.GetList());
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok(customerService.GetById(id));
        }
        [HttpGet("name")]
        public IActionResult GetListLike(string name)
        {
            return Ok(customerService.GetListLike(name));
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CustomerViewModel customer)
        {
            return Ok(customerService.Insert(customer));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, CustomerViewModel customer)
        {
            return Ok(customerService.Update(id, customer));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(customerService.Delete(id));
        }
    }
}
