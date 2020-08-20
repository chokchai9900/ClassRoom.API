using ClassRoom.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Interface
{
    interface IPersionManage<T>
    {
        List<T> Get();
        T GetById(string id);
        T Create(T data);
        bool Edit(T TeacherData);
        void Remove(string TeacherId);
    }
}
