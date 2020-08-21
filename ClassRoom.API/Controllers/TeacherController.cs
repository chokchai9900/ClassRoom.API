using ClassRoom.API.Interface;
using ClassRoom.API.Models;
using ClassRoom.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ClassRoom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        // GET: api/<Teacher>
        static readonly IPersionManage<TeacherModel> _TeacherService = new TeacherService();
        /// <summary>
        /// Get All teacher
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TeacherModel>> GetTeacher()
        {
            return _TeacherService.Get(); ;
        }

        /// <summary>
        /// Get teacher By Id
        /// </summary>
        /// <param name="StdId"></param>
        /// <returns></returns>
        [HttpGet("{StdId}")]
        public ActionResult<TeacherModel> GetTeacherById(string StdId)
        {
            var teacher = _TeacherService.GetById(StdId);
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
            _TeacherService.Create(data);
        }

        /// <summary>
        /// Edit teacher data
        /// </summary>
        /// <param name="data"></param>
        [HttpPut("{TeacherModel}")]
        public IActionResult EditTeacher([FromBody] TeacherModel data)
        {
            var result = _TeacherService.Edit(data);
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
        public IActionResult DeleteTeacher(string techID)
        {
            var validate = _TeacherService.GetById(techID);
            if (validate != null)
            {
                _TeacherService.Remove(techID);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
