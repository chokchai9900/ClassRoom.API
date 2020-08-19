using ClassRoom.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Interface
{
    interface IStudentManage
    {
        List<StudentModel> GetStudent();
        StudentModel GetStudentById(string id);
        StudentModel CreateStudent(StudentModel data);
        bool EditStudent(StudentModel stdData);
        void RemoveStudent(string stdId);
    }
}
