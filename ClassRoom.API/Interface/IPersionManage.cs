using ClassRoom.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Interface
{
    interface IPersionManage<T>
    {
        public Task<List<T>> Get();
        public Task<T> GetById(string id);
        public Task<T> Create(T data);
        public Task<bool> Edit(T TeacherData);
        public void Remove(string TeacherId);
    }
}
