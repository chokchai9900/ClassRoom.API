using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Models
{
    interface IClassRoomRepository
    {
        List<StudentModel> GetStudent();
        StudentModel GetStudentById(string id);
        StudentModel CreateStudent(StudentModel data);
        bool EditStudent(StudentModel stdData);
        void RemoveStudent(string stdId);

        List<TeacherModel> GetTeacher();
        TeacherModel GetTeacherById(string id);
        TeacherModel CreateTeacher(TeacherModel data);
        bool EditTeacher(TeacherModel TeacherData);
        void RemoveTeacher(string TeacherId);

        List<ClassRoomModel> GetClassRoom();
        ClassRoomModel GetDataByClassRoomId(string id);
        ClassRoomModel CreateClassRoom(string classroomId,string classroomName);
        bool AddTeacherInClassByClassRoomId(string classId, string teacherId);
        bool AddStudentInClassByClassRoomId(string classId, string stdId);
        void RemoveClassRoom(string ClassRoomId);
    }
}
