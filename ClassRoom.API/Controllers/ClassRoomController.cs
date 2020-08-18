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
        public List<ClassRoomModel> GetClassroom()
        {
            return _ClassRoomservice.GetClassRoom();
        }
        /// <summary>
        /// Get classroom by id
        /// </summary>
        /// <param name="ClassRoomID"></param>
        /// <returns></returns>
        [HttpGet("{ClassRoomID}")]
        public ClassRoomModel GetClassRoomByID(string ClassRoomID)
        {
            return _ClassRoomservice.GetDataByClassRoomId(ClassRoomID);
        }
        /// <summary>
        /// Create ClassRoom
        /// </summary>
        /// <param name="classroomId"></param>
        /// <param name="classroomName"></param>
        [HttpPost("{classroomId,classroomName}")]
        public void CreateClassRoom(string classroomId, string classroomName)
        {
            _ClassRoomservice.CreateClassRoom(classroomId, classroomName);
        }
        /// <summary>
        /// Add Teacher  in classroom by id
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="teacherId"></param>
        [HttpPut("{classId,teacherId}")]
        public void AddTeacher(string classId, string teacherId)
        {
            _ClassRoomservice.AddTeacherInClassByClassRoomId(classId, teacherId);
        }
        /// <summary>
        /// Add Student  in classroom by id
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="studentId"></param>
        [HttpPut("{classId,studentId}")]
        public void AddStudent(string classId, string studentId)
        {
            _ClassRoomservice.AddTeacherInClassByClassRoomId(classId, studentId);
        }
        /// <summary>
        /// delete classroom
        /// </summary>
        /// <param name="ClassRoomId"></param>
        [HttpDelete("{ClassRoomId}")]
        public void DeleteClassRoom(string ClassRoomId)
        {
            _ClassRoomservice.RemoveClassRoom(ClassRoomId);
        }
    }
}
