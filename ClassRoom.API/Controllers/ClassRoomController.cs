using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using ClassRoom.API.Models;
using ClassRoom.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassRoom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        static readonly IClassRoomRepository _ClassRoomservice = new ClassRoomService();
        /// <summary>
        /// Get All Classroom
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ClassRoomModel>>> GetClassroom()
        {
            return _ClassRoomservice.GetClassRoom();
        }
        /// <summary>
        /// Get classroom by id
        /// </summary>
        /// <param name="ClassRoomID"></param>
        /// <returns></returns>
        [HttpGet("{ClassRoomID}")]
        public async Task<ActionResult<ClassRoomModel>> GetClassRoomByID(string ClassRoomID)
        {
            var classroom = _ClassRoomservice.GetDataByClassRoomId(ClassRoomID);
            if (classroom == null)
            {
                return NotFound();
            }
            return classroom;
        }
        /// <summary>
        /// Create ClassRoom
        /// </summary>
        /// <param name="classroomId"></param>
        /// <param name="classroomName"></param>
        [HttpPost]
        public void CreateClassRoom(string classroomId, string classroomName)
        {
            _ClassRoomservice.CreateClassRoom(classroomId, classroomName);
        }
        /// <summary>
        /// Add Teacher  in classroom by id
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="teacherId"></param>
        [HttpPut("{teacherId}")]
        public async Task<IActionResult> AddTeacher(string classId, string teacherId)
        {
            var result = _ClassRoomservice.AddTeacherInClassByClassRoomId(classId, teacherId);
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
        /// <param name="classId"></param>
        /// <param name="studentId"></param>
        [HttpPut("{studentId}")]
        public async Task<IActionResult> AddStudent(string classId, string studentId)
        {
            var result =  _ClassRoomservice.AddTeacherInClassByClassRoomId(classId, studentId);
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
        public async Task<IActionResult> DeleteClassRoom(string ClassRoomId)
        {
            var validate = _ClassRoomservice.GetDataByClassRoomId(ClassRoomId);
            if (validate != null)
            {
                _ClassRoomservice.RemoveClassRoom(ClassRoomId);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
