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
        /// <summary>
        /// Get All Student
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StudentModel>> GetStudent()
        {
            return _StudentService.Get(); ;
        }

        /// <summary>
        /// Get student By Id
        /// </summary>
        /// <param name="StdId"></param>
        /// <returns></returns>
        [HttpGet("{StdId}")]
        public ActionResult<StudentModel> GetStudentById(string StdId)
        {
            var student = _StudentService.GetById(StdId);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        /// <summary>
        /// Add student data
        /// </summary>
        /// <param name="data"></param>
        [HttpPost]
        public void CreateStudent([FromBody] StudentModel data)
        {
            _StudentService.Create(data);
        }

        /// <summary>
        /// Edit student data
        /// </summary>
        /// <param name="data"></param>
        [HttpPut("{StudentModel}")]
        public IActionResult EditStudent([FromBody] StudentModel data)
        {
            var result = _StudentService.Edit(data);
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
            var validate = _StudentService.GetById(stdId);
            if (validate != null)
            {
                _StudentService.Remove(stdId);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
