using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Customer;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Customer;
using SWD392.OutfitBox.BusinessLayer.Services.UserService;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<ActionResult<BaseResponse<List<CustomerDTO>>>> GetAllUsers()
        {
            BaseResponse<List<CustomerDTO>> response;
            try
            {
                var data = await _customerService.GetAllCustomers(); 
                response = new BaseResponse<List<CustomerDTO>>("Get customers successfully.", HttpStatusCode.OK ,data);

            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<CustomerDTO>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet(CustomerEndpoints.GetCustomerById)]
        public async Task<ActionResult<BaseResponse<CustomerDTO>>> GetCustomerById([FromRoute] int id)
        {
            BaseResponse<CustomerDTO> response;
            try
            {
                var data = await _customerService.GetCustomerById(id);
                response = new BaseResponse<CustomerDTO>("Get customers successfully.", HttpStatusCode.OK, data);

            }
            catch (ArgumentNullException ex)
            {

                response = new BaseResponse<CustomerDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CustomerDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(CustomerEndpoints.CreateCustomer)]
        public async Task<ActionResult<BaseResponse<CreateCustomerResponseDTO>>> CreateCustomer([FromBody] CreateCustomerRequestDTO createCustomerRequestDTO)
        {
            BaseResponse<CreateCustomerResponseDTO> response;
            try
            {
                var data = await _customerService.CreateCustomer(createCustomerRequestDTO);
                response = new BaseResponse<CreateCustomerResponseDTO>("Create customer successfully.", HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreateCustomerResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("customers")]
        public async Task<ActionResult<UpdateCustomerResponseDTO>> UpdateCustomer([FromBody] UpdateCustomerRequestDTO updateCustomerRequestDTO)
        {
            BaseResponse<UpdateCustomerResponseDTO> response;
            try
            {
                var data = await _customerService.UpdateCustomer(updateCustomerRequestDTO);
                response = new BaseResponse<UpdateCustomerResponseDTO>("Update customer successfully.", HttpStatusCode.OK, data);

            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<UpdateCustomerResponseDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<UpdateCustomerResponseDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch(CustomerEndpoints.ActiveOrDeactiveCustomer)]
        public async Task<ActionResult<CustomerDTO>> ActiveOrDeactiveCustomer([FromRoute] int id)
        {
            BaseResponse<CustomerDTO> response;
            try
            {
                var data = await _customerService.ActiveAndDeactiveCustomer(id);
                response = new BaseResponse<CustomerDTO>("Update customer successfully.", HttpStatusCode.OK, data);

            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<CustomerDTO>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CustomerDTO>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }

    }
}
