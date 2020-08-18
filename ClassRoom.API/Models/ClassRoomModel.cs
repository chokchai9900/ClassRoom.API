using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Models
{
    public class ClassRoomModel
    {
        public string classRoomId { get; set; }
        public string classRoomName { get; set; }
        public StudentModel[] classStudent { get; set; }
        public TeacherModel[] classTeacher { get; set; }
    }
}
