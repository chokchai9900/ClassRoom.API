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
        public List<TeacherModel> GetTeacher()
        {
            return _TeacherService.GetTeacher(); ;
        }

        /// <summary>
        /// Get teacher By Id
        /// </summary>
        /// <param name="StdId"></param>
        /// <returns></returns>
        [HttpGet("{StdId}")]
        public TeacherModel GetTeacherById(string StdId)
        {
            return _TeacherService.GetTeacherById(StdId);
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
        public void EditTeacher([FromBody] TeacherModel data)
        {
            _TeacherService.EditTeacher(data);
        }

        /// <summary>
        /// delete teachers
        /// </summary>
        /// <param name="techID"></param>
        [HttpDelete("{techID}")]
        public void DeleteTeacher(string techID)
        {
            _TeacherService.RemoveTeacher(techID);
        }
    }
}
