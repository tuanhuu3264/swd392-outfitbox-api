using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Customer;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Customer;
using SWD392.OutfitBox.BusinessLayer.Services.UserService;

namespace SWD392.OutfitBox.API.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet(CustomerEndpoints.GetAllCustomers)]
        public async Task<ActionResult<List<CustomerDTO>>> GetAllUsers()
        {
            return Ok(await _customerService.GetAllCustomers());
        }
        [HttpGet(CustomerEndpoints.GetCustomerById)]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById([FromRoute] int id)
        {
            return Ok(await _customerService.GetCustomerById(id));
        }
        [HttpPost(CustomerEndpoints.CreateCustomer)]
        public async Task<ActionResult<CreateCustomerResponseDTO>> CreateCustomer([FromBody] CreateCustomerRequestDTO createCustomerRequestDTO)
        {
            var result = await _customerService.CreateCustomer(createCustomerRequestDTO);
            return Ok(result);
        }
        [HttpPut(CustomerEndpoints.UpdateCustomer)]
        public async Task<ActionResult<UpdateCustomerResponseDTO>> UpdateCustomer([FromBody] UpdateCustomerRequestDTO updateCustomerRequestDTO)
        {
            var result = await _customerService.UpdateCustomer(updateCustomerRequestDTO);
            return Ok(result);
        }
        [HttpPut(CustomerEndpoints.ActiveOrDeactiveCustomer)]
        public async Task<ActionResult<CustomerDTO>> ActiveOrDeactiveCustomer([FromRoute] int id)
        {
           return Ok(await _customerService.ActiveAndDeactiveCustomer(id));
        }
       
    }
}
