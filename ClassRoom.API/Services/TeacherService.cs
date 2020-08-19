using ClassRoom.API.Interface;
using ClassRoom.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Services
{
    public class TeacherService : ITeacherManage
    {
        private List<TeacherModel> _TeacherList = new List<TeacherModel>();
        public TeacherModel CreateTeacher(TeacherModel data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            _TeacherList.Add(data);
            return data;
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

        public List<TeacherModel> GetTeacher()
        {
            return _TeacherList;
        }

        public TeacherModel GetTeacherById(string id)
        {
            return _TeacherList.Find(it => it.teacherId == id);
        }

        public void RemoveTeacher(string TeacherId)
        {
            _TeacherList.RemoveAll(it => it.teacherId == TeacherId);
        }
    }
}
