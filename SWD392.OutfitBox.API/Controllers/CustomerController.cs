using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.API.Configurations.HTTPResponse;
using SWD392.OutfitBox.API.Controllers.Endpoints;
using SWD392.OutfitBox.API.DTOs.Customer;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

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
        public IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet(CustomerEndpoints.GetAllCustomers)]
        public async Task<ActionResult<BaseResponse<List<CustomerModel>>>> GetAllUsers()
        {
            BaseResponse<List<CustomerModel>> response;
            try
            {
                var data = await _customerService.GetAllCustomers(); 
                response = new BaseResponse<List<CustomerModel>>("Get customers successfully.", HttpStatusCode.OK ,data);

            }
            catch (Exception ex)
            {
                response = new BaseResponse<List<CustomerModel>>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet(CustomerEndpoints.GetCustomerById)]
        public async Task<ActionResult<BaseResponse<CustomerModel>>> GetCustomerById([FromRoute] int id)
        {
            BaseResponse<CustomerModel> response;
            try
            {
                var data = await _customerService.GetCustomerById(id);
                response = new BaseResponse<CustomerModel>("Get customers successfully.", HttpStatusCode.OK, data);

            }
            catch (ArgumentNullException ex)
            {

                response = new BaseResponse<CustomerModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CustomerModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }
            
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(CustomerEndpoints.CreateCustomer)]
        public async Task<ActionResult<BaseResponse<CustomerModel>>> CreateCustomer([FromBody] CreateCustomerRequestDTO createCustomerRequestDTO)
        {
            BaseResponse<CustomerModel> response;
            try
            {   
                var mapping = _mapper.Map<CustomerModel>(createCustomerRequestDTO);
                var data = await _customerService.CreateCustomer(mapping);
                response = new BaseResponse<CustomerModel>("Create customer successfully.", HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                response = new BaseResponse<CustomerModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch("customers/{id}")]
        public async Task<ActionResult<CustomerModel>> UpdateCustomer([FromRoute] int id, [FromBody] UpdateCustomerRequestDTO updateCustomerRequestDTO)
        {
            BaseResponse<CustomerModel> response;
            try
            {
                var mapping = _mapper.Map<CustomerModel>(updateCustomerRequestDTO);
                mapping.Id = id;
                var data = await _customerService.UpdateCustomer(mapping);
                response = new BaseResponse<CustomerModel>("Update customer successfully.", HttpStatusCode.OK, data);

            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<CustomerModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CustomerModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPatch(CustomerEndpoints.ActiveOrDeactiveCustomer)]
        public async Task<ActionResult<CustomerModel>> ActiveOrDeactiveCustomer([FromRoute] int id)
        {
            BaseResponse<CustomerModel> response;
            try
            {
                var data = await _customerService.ActiveAndDeactiveCustomer(id);
                response = new BaseResponse<CustomerModel>("Update customer successfully.", HttpStatusCode.OK, data);

            }
            catch (ArgumentNullException ex)
            {
                response = new BaseResponse<CustomerModel>(ex.Message, HttpStatusCode.NotFound, null);
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CustomerModel>(ex.Message, HttpStatusCode.InternalServerError, null);
            }

            return StatusCode((int)response.StatusCode, response);
        }

    }
}
