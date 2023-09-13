using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.APIs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRep employee;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRep employee, IMapper mapper)
        {
            this.employee = employee;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("~/Api/GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                var data = employee.Get();
                var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return Ok(new ApiResponse<IEnumerable<EmployeeVM>>() { 
                
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrieved",
                    Data = model
                
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Error = ex.Message

                });
            }
            
        }


        [HttpGet]
        [Route("~/Api/GetEmployeesById/{id}")]
        public IActionResult GetEmployeesById(int id)
        {
            try
            {
                var data = employee.GetById(id);
                var model = mapper.Map<EmployeeVM>(data);
                return Ok(new ApiResponse<EmployeeVM>()
                {

                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrieved",
                    Data = model

                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Error = ex.Message

                });
            }

        }


        [HttpPost]
        [Route("~/Api/PostEmployee")]
        public IActionResult PostEmployee(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    var result = employee.Create(data);
                    return Ok(new ApiResponse<Employee>()
                    {

                        Code = "201",
                        Status = "Created",
                        Message = "Data Saved",
                        Data = result
                    });
                }
                return Ok(new ApiResponse<string>()
                {

                    Code = "400",
                    Status = "Not Valied",
                    Message = "Data Invalied"
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = "404",
                    Status = "Not Saved",
                    Message = "Data Not Saved",
                    Error = ex.Message

                });
            }

        }


        [HttpPut]
        [Route("~/Api/PutEmployee")]
        public IActionResult PutEmployee(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    var result = employee.Edit(data);
                    return Ok(new ApiResponse<Employee>()
                    {

                        Code = "200",
                        Status = "Ok",
                        Message = "Data Updated",
                        Data = result
                    });
                }
                return Ok(new ApiResponse<string>()
                {

                    Code = "400",
                    Status = "Not Valied",
                    Message = "Data Invalied"
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = "404",
                    Status = "Not Saved",
                    Message = "Data Not Saved",
                    Error = ex.Message

                });
            }

        }


        [HttpDelete]
        [Route("~/Api/DeleteEmployee")]
        public IActionResult DeleteEmployee(EmployeeVM model)
        {
            try
            {
                
                    var data = mapper.Map<Employee>(model);
                    employee.Delete(data);
                    return Ok(new ApiResponse<Employee>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Data Deleted",
                        Data = data
                    });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = "404",
                    Status = "Not Saved",
                    Message = "Data Not Saved",
                    Error = ex.Message

                });
            }

        }
    }
}
