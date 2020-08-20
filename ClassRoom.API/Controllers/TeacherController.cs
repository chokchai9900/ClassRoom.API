using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoom.API.Interface;
using ClassRoom.API.Models;
using ClassRoom.API.Services;
using Microsoft.AspNetCore.Mvc;


namespace ClassRoom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        // GET: api/<Teacher>
        static readonly ITeacherManage _TeacherService = new TeacherService();
        /// <summary>
        /// Get All teacher
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<TeacherModel>>> GetTeacher()
        {
            return _TeacherService.GetTeacher(); ;
        }

        /// <summary>
        /// Get teacher By Id
        /// </summary>
        /// <param name="StdId"></param>
        /// <returns></returns>
        [HttpGet("{StdId}")]
        public async Task<ActionResult<TeacherModel>> GetTeacherById(string StdId)
        {
            var teacher = _TeacherService.GetTeacherById(StdId);
            if (teacher == null)
            {
                return NotFound();
            }
            return teacher;
        }

        /// <summary>
        /// Add teacher data
        /// </summary>
        /// <param name="data"></param>
        [HttpPost]
        public void CreateTeacher([FromBody] TeacherModel data)
        {
            _TeacherService.CreateTeacher(data);
        }

        /// <summary>
        /// Edit teacher data
        /// </summary>
        /// <param name="data"></param>
        [HttpPut("{TeacherModel}")]
        public async Task<IActionResult> EditTeacher([FromBody] TeacherModel data)
        {
            var result = _TeacherService.EditTeacher(data);
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
        /// delete teachers
        /// </summary>
        /// <param name="techID"></param>
        [HttpDelete("{techID}")]
        public async Task<IActionResult> DeleteTeacher(string techID)
        {
            var validate = _TeacherService.GetTeacherById(techID);
            if (validate != null)
            {
                _TeacherService.RemoveTeacher(techID);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
