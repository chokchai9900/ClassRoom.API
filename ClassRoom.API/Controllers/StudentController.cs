using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        static readonly IClassRoomRepository _ClassRoomservice = new ClassRoomService();
        /// <summary>
        /// Get All Student
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<StudentModel> GetStudent()
        {
            return _ClassRoomservice.GetStudent(); ;
        }

        /// <summary>
        /// Get student By Id
        /// </summary>
        /// <param name="StdId"></param>
        /// <returns></returns>
        [HttpGet("{StdId}")]
        public StudentModel GetStudentById(string StdId)
        {
            return _ClassRoomservice.GetStudentById(StdId);
        }

        /// <summary>
        /// Add student data
        /// </summary>
        /// <param name="data"></param>
        [HttpPost]
        public void CreateStudent([FromBody] StudentModel data)
        {
            _ClassRoomservice.CreateStudent(data);
        }

        /// <summary>
        /// Edit student data
        /// </summary>
        /// <param name="data"></param>
        [HttpPut("{StudentModel}")]
        public void EditStudent([FromBody] StudentModel data)
        {
            _ClassRoomservice.EditStudent(data);
        }

        /// <summary>
        /// delete student
        /// </summary>
        /// <param name="stdId"></param>
        [HttpDelete("{stdId}")]
        public void DeleteStudent(string stdId)
        {
            _ClassRoomservice.RemoveStudent(stdId);
        }
    }
}
