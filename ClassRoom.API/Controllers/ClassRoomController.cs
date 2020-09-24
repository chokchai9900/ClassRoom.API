using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRoom.API.Models;
using ClassRoom.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        static readonly IClassRoomRepository<ClassRoomModel> _ClassRoomservice = new ClassRoomService();

        internal static IClassRoomRepository<ClassRoomModel> ClassRoomservice => _ClassRoomservice;

        /// <summary>
        /// Get All Classroom
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ClassRoomModel>>> GetClassroomAsync()
        {
            return await ClassRoomservice.GetClassRoom();
        }
        /// <summary>
        /// Get classroom by id
        /// </summary>
        /// <param name="ClassRoomID"></param>
        /// <returns></returns>
        [HttpGet("{ClassRoomID}")]
        public async Task<ActionResult<ClassRoomModel>> GetClassRoomByIDAsync(string ClassRoomID)
        {
            var classroom = ClassRoomservice.GetDataByClassRoomId(ClassRoomID);
            if (classroom == null)
            {
                return NotFound();
            }
            return await classroom;
        }
        /// <summary>
        /// Create ClassRoom
        /// </summary>
        /// <param name="classroomId"></param>
        /// <param name="classroomName"></param>
        [HttpPost]
        public void CreateClassRoom(string classroomId, string classroomName)
        {
            ClassRoomservice.CreateClassRoom(classroomId, classroomName);
        }
        /// <summary>
        /// Add Teacher  in classroom by id
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="classId"></param>
        [HttpPut("AddTeacherAsync/{teacherId}")]
        public async Task<IActionResult> AddTeacherAsync(string teacherId, string classId)
        {
            var result = await ClassRoomservice.AddTeacherInClassByClassRoomId(classId, teacherId);
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
        /// Add Student  in classroom by id
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="classId"></param>
        [HttpPut("AddStudentAsync/{studentId}")]
        public async Task<IActionResult> AddStudentAsync(string studentId, string classId)
        {
            var result = await ClassRoomservice.AddStudentInClassByClassRoomIdAsync(classId, studentId);
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
        /// delete classroom
        /// </summary>
        /// <param name="ClassRoomId"></param>
        [HttpDelete("{ClassRoomId}")]
        public IActionResult DeleteClassRoom(string ClassRoomId)
        {
            var validate = ClassRoomservice.GetDataByClassRoomId(ClassRoomId);
            if (validate != null)
            {
                ClassRoomservice.RemoveClassRoom(ClassRoomId);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
