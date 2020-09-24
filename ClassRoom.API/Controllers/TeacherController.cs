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

        internal static IPersionManage<TeacherModel> TeacherService => _TeacherService;

        /// <summary>
        /// Get All teacher
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<TeacherModel>>> GetTeacherAsync()
        {
            return await TeacherService.Get(); ;
        }

        /// <summary>
        /// Get teacher By Id
        /// </summary>
        /// <param name="StdId"></param>
        /// <returns></returns>
        [HttpGet("{StdId}")]
        public async Task<ActionResult<TeacherModel>> GetTeacherByIdAsync(string StdId)
        {
            var teacher = TeacherService.GetById(StdId);
            if (teacher == null)
            {
                return NotFound();
            }
            return await teacher;
        }

        /// <summary>
        /// Add teacher data
        /// </summary>
        /// <param name="data"></param>
        [HttpPost]
        public void CreateTeacher([FromBody] TeacherModel data)
        {
            TeacherService.Create(data);
        }

        /// <summary>
        /// Edit teacher data
        /// </summary>
        /// <param name="data"></param>
        [HttpPut("{TeacherModel}")]
        public async Task<IActionResult> EditTeacherAsync([FromBody] TeacherModel data)
        {
            var result = await TeacherService.Edit(data);
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
            var validate = TeacherService.GetById(techID);
            if (validate != null)
            {
                TeacherService.Remove(techID);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
