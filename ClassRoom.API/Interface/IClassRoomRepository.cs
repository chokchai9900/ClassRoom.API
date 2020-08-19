using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Models
{
    interface IClassRoomRepository
    {
        List<ClassRoomModel> GetClassRoom();
        ClassRoomModel GetDataByClassRoomId(string id);
        ClassRoomModel CreateClassRoom(string classroomId,string classroomName);
        bool AddTeacherInClassByClassRoomId(string classId, string teacherId);
        bool AddStudentInClassByClassRoomId(string classId, string stdId);
        void RemoveClassRoom(string ClassRoomId);
    }
}
