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

        public StudentModel CreateStudent(StudentModel data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            _StudentList.Add(data);
            return data;
        }

        public TeacherModel CreateTeacher(TeacherModel data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            _TeacherList.Add(data);
            return data;
        }

        public bool EditStudent(StudentModel stdData)
        {
            if (stdData == null)
            {
                throw new ArgumentNullException("data");
            }
            int index = _StudentList.FindIndex(p => p.studentId == stdData.studentId);
            if (index == -1)
            {
                return false;
            }
            _StudentList.RemoveAt(index);
            _StudentList.Add(stdData);
            return true;
        }

        public bool EditTeacher(TeacherModel TeacherData)
        {
            if (TeacherData == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = _TeacherList.FindIndex(p => p.teacherId == TeacherData.teacherId);
            if (index == -1)
            {
                return false;
            }
            _TeacherList.RemoveAt(index);
            _TeacherList.Add(TeacherData);
            return true;
        }

        public List<ClassRoomModel> GetClassRoom()
        {
            return _ClassRoomsList;
        }

        public ClassRoomModel GetDataByClassRoomId(string id)
        {
            return _ClassRoomsList.Find(it => it.classRoomId == id);
        }

        public List<StudentModel> GetStudent()
        {
            return _StudentList;
        }

        public StudentModel GetStudentById(string id)
        {
            return _StudentList.Find(it => it.studentId == id);
        }

        public List<TeacherModel> GetTeacher()
        {
            return _TeacherList;
        }

        public TeacherModel GetTeacherById(string id)
        {
            return _TeacherList.Find(it => it.teacherId == id);
        }

        public void RemoveClassRoom(string ClassRoomId)
        {
            _ClassRoomsList.RemoveAll(it => it.classRoomId == ClassRoomId);
        }

        public void RemoveStudent(string stdId)
        {
            _StudentList.RemoveAll(it => it.studentId == stdId);
        }

        public void RemoveTeacher(string TeacherId)
        {
            _TeacherList.RemoveAll(it => it.teacherId == TeacherId);
        }
    }
}
