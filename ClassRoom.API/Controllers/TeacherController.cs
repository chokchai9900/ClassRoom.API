using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        static readonly IClassRoomRepository _ClassRoomservice = new ClassRoomService();
        /// <summary>
        /// Get All teacher
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<TeacherModel> GetTeacher()
        {
            return _ClassRoomservice.GetTeacher(); ;
        }

        /// <summary>
        /// Get teacher By Id
        /// </summary>
        /// <param name="StdId"></param>
        /// <returns></returns>
        [HttpGet("{StdId}")]
        public TeacherModel GetTeacherById(string StdId)
        {
            return _ClassRoomservice.GetTeacherById(StdId);
        }

        /// <summary>
        /// Add teacher data
        /// </summary>
        /// <param name="data"></param>
        [HttpPost]
        public void CreateTeacher([FromBody] TeacherModel data)
        {
            _ClassRoomservice.CreateTeacher(data);
        }

        /// <summary>
        /// Edit teacher data
        /// </summary>
        /// <param name="data"></param>
        [HttpPut("{TeacherModel}")]
        public void EditTeacher([FromBody] TeacherModel data)
        {
            _ClassRoomservice.EditTeacher(data);
        }

        /// <summary>
        /// delete teachers
        /// </summary>
        /// <param name="techID"></param>
        [HttpDelete("{techID}")]
        public void DeleteTeacher(string techID)
        {
            _ClassRoomservice.RemoveTeacher(techID);
        }
    }
}
