using Microsoft.EntityFrameworkCore;
using ShowRoomManagment_API.Data;
using ShowRoomManagment_API.DTOs;
using ShowRoomManagment_API.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace ShowRoomManagment_API.Models
{
    public class DepartmentModel : IDepartment
    {
        private readonly ApplicationDbContext db_Context;

        public DepartmentModel(ApplicationDbContext dbContext)
        {
            this.db_Context = dbContext;
        }

        public async Task<ResponseDTO> AddDepartment(DepartmentDTO departmentDTO)
        {
            var response = new ResponseDTO();
            try
            {
                var department = new Department()
                {
                    Name = departmentDTO.Name,
                    Description = departmentDTO.Description
                };
              await  db_Context.Departments.AddAsync(department);
                await db_Context.SaveChangesAsync();
                response.Response = "Department Created Successfully";
            }

            catch(Exception ex)
            {
                response.ErrorMassage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseDTO> DeleteDepartment(int Id)
        {
            var respone = new ResponseDTO();

            try {
                var data = await db_Context.Departments.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if(data!= null)
                {
                    db_Context.Departments.Remove(data);
                    await db_Context.SaveChangesAsync();
                }
            }

  catch(Exception ex)
            {
                respone.ErrorMassage = ex.Message;
            }

            return respone;
            
        }

        public async Task<ResponseDTO> GetDepartmentById(int Id)
        {
            var response = new ResponseDTO();

            try
            {
                var department = await db_Context.Departments.Where(x => x.Id == Id).FirstOrDefaultAsync();
                 if(department!= null)
                {
                    response.StatusCode = 404;
                }
                else
                {
                    response.Response = department;
                }
            }
            catch(Exception ex)
            {
                response.ErrorMassage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseDTO> GetDepartments()
        {
           
            var response = new ResponseDTO();
            try
            {
                response.Response=await db_Context.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                response.ErrorMassage = ex.Message;
            }
            return response;
        }

      
        public async Task<ResponseDTO> UpdateDepartment(DepartmentDTO departmentDTO)
        {
            var response = new ResponseDTO();
            try
            {
              var record = await db_Context.Departments.Where(x=>x.Id== departmentDTO.Id).FirstOrDefaultAsync();
                record.Name = departmentDTO.Name;
                record.Description = departmentDTO.Description;
                db_Context.Departments.Update(record);
                await db_Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ErrorMassage = ex.Message;
            }
            return response;
        }
    }
}
