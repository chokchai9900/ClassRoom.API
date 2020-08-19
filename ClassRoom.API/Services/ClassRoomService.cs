using ClassRoom.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ClassRoom.API.Services
{
    public class ClassRoomService : IClassRoomRepository
    {
        private List<StudentModel> _StudentList = new List<StudentModel>();
        private List<TeacherModel> _TeacherList = new List<TeacherModel>();
        private List<ClassRoomModel> _ClassRoomsList = new List<ClassRoomModel>();

        public ClassRoomService()
        {

        }

        public bool AddStudentInClassByClassRoomId(string classId, string stdId)
        {
            if (stdId == null || classId == null)
            {
                throw new ArgumentNullException("data");
            }
            var classRoom = _ClassRoomsList.Find(it => it.classRoomId == classId);
            var student = _StudentList.Find(it => it.studentId == stdId);
            var validate = Array.Find(classRoom.classStudent, it => it.studentId == stdId);
            var addindex = classRoom.classStudent.Count();
            if (validate != null)
            {
                classRoom.classStudent[addindex] = student;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddTeacherInClassByClassRoomId(string classId, string teacherId)
        {
            if (teacherId == null || classId == null)
            {
                throw new ArgumentNullException("data");
            }
            var classRoom = _ClassRoomsList.Find(it => it.classRoomId == classId);
            var teacher = _TeacherList.Find(it => it.teacherId == teacherId);
            var validate = Array.Find(classRoom.classTeacher, it => it.teacherId == teacherId);
            var addindex = classRoom.classTeacher.Count();
            if (validate != null)
            {
                classRoom.classTeacher[addindex] = teacher;
                return true;
            }
            else
            {
                return false;
            }
        }
        public ClassRoomModel CreateClassRoom(string classroomId, string classroomName)
        {
            var newRoom = new ClassRoomModel()
            {
                classRoomId = classroomId,
                classRoomName = classroomName,
                classStudent = null,
                classTeacher = null
            };
            _ClassRoomsList.Add(newRoom);
            return newRoom;
        }
        public List<ClassRoomModel> GetClassRoom()
        {
            return _ClassRoomsList;
        }
        public ClassRoomModel GetDataByClassRoomId(string id)
        {
            return _ClassRoomsList.Find(it => it.classRoomId == id);
        }
        public void RemoveClassRoom(string ClassRoomId)
        {
            _ClassRoomsList.RemoveAll(it => it.classRoomId == ClassRoomId);
        }
    }
}
