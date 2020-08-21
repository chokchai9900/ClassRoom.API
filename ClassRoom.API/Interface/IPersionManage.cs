using ClassRoom.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Interface
{
    interface IPersionManage<T>
    {
        public List<T> Get();
        public T GetById(string id);
        public T Create(T data);
        public bool Edit(T TeacherData);
        public void Remove(string TeacherId);
    }
}
