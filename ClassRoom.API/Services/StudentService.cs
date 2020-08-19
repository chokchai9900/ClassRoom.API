using ClassRoom.API.Interface;
using ClassRoom.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Services
{
    public class StudentService : IStudentManage
    {
        private List<StudentModel> _StudentList = new List<StudentModel>();
        public StudentModel CreateStudent(StudentModel data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            _StudentList.Add(data);
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

        public List<StudentModel> GetStudent()
        {
            return _StudentList;
        }

        public StudentModel GetStudentById(string id)
        {
            return _StudentList.Find(it => it.studentId == id);
        }

        public void RemoveStudent(string stdId)
        {
            _StudentList.RemoveAll(it => it.studentId == stdId);
        }
    }
}
