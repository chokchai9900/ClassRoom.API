using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Models
{
    interface IClassRoomRepository<T>
    {
        public Task<List<T>> GetClassRoom();
        public Task<T> GetDataByClassRoomId(string id);
        public Task<T> CreateClassRoom(string classroomId,string classroomName);
        public Task<bool> AddTeacherInClassByClassRoomId(string classId, string teacherId);
        public Task<bool> AddStudentInClassByClassRoomIdAsync(string classId, string stdId);
        void RemoveClassRoom(string ClassRoomId);
    }
}
