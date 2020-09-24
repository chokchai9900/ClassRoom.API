using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoom.API.Interface;
using ClassRoom.API.Models;
using ClassRoom.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassRoom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static readonly IPersionManage<StudentModel> _StudentService = new StudentService();

        internal static IPersionManage<StudentModel> StudentService => _StudentService;

        /// <summary>
        /// Get All Student
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<StudentModel>>> GetStudentAsync()
        {
            return await StudentService.Get(); ;
        }

        /// <summary>
        /// Get student By Id
        /// </summary>
        /// <param name="StdId"></param>
        /// <returns></returns>
        [HttpGet("{StdId}")]
        public async Task<ActionResult<StudentModel>> GetStudentByIdAsync(string StdId)
        {
            var student = StudentService.GetById(StdId);
            if (student == null)
            {
                return NotFound();
            }
            return await student;
        }

        /// <summary>
        /// Add student data
        /// </summary>
        /// <param name="data"></param>
        [HttpPost]
        public void CreateStudent([FromBody] StudentModel data)
        {
            StudentService.Create(data);
        }

        /// <summary>
        /// Edit student data
        /// </summary>
        /// <param name="data"></param>
        [HttpPut("{StudentModel}")]
        public async Task<IActionResult> EditStudentAsync([FromBody] StudentModel data)
        {
            var result = await StudentService.Edit(data);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// delete student
        /// </summary>
        /// <param name="stdId"></param>
        [HttpDelete("{stdId}")]
        public IActionResult DeleteStudent(string stdId)
        {
            var validate = StudentService.GetById(stdId);
            if (validate != null)
            {
                StudentService.Remove(stdId);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
