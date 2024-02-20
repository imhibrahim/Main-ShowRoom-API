using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowRoomManagment_API.DTOs;
using ShowRoomManagment_API.Repositories;

namespace ShowRoomManagment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment service;

        public DepartmentController(IDepartment _service)
        {
            this.service = _service;
        }


        [HttpGet("GetDepartments")]
        public async Task<string> GetDepartments()
        {
            var data =await service.GetDepartments();
            var convertesData = JsonConvert.SerializeObject(data);
            return convertesData;
        }




        [HttpPost("AddDepartment")]

        public async Task<string> AddDepartment(DepartmentDTO departmentDTO)
        {
           return JsonConvert.SerializeObject(await service.AddDepartment(departmentDTO));
        }
        [HttpGet("DeleteDepartment")]
        public async Task<string> DeleteDepartment( int Id)
        {
            return JsonConvert.SerializeObject(await service.DeleteDepartment(Id));
        }
        [HttpGet("GetDepartmentById")]
        public async Task<string> GetDepartmentById(int Id)
        {
            return JsonConvert.SerializeObject(await service.GetDepartmentById(Id));
        }

        [HttpPost("UpdateDepartment")]
        public async Task<string> UpdateDepartment(DepartmentDTO departmentDTO) {

            return JsonConvert.SerializeObject(await service.UpdateDepartment(departmentDTO));
        }
    }
}
