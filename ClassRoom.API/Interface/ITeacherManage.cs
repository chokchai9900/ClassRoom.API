using ClassRoom.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Interface
{
    interface ITeacherManage
    {
        List<TeacherModel> GetTeacher();
        TeacherModel GetTeacherById(string id);
        TeacherModel CreateTeacher(TeacherModel data);
        bool EditTeacher(TeacherModel TeacherData);
        void RemoveTeacher(string TeacherId);
    }
}
