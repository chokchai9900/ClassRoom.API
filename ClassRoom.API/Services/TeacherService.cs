using ClassRoom.API.Interface;
using ClassRoom.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Services
{
    public class TeacherService : IPersionManage<TeacherModel>
    {
        static readonly DBContext _dBContext = new DBContext();
        public IMongoCollection<TeacherModel> connectTeacherCollection { get; set; }
        public TeacherService()
        {
            connectTeacherCollection = _dBContext.MongoCollectionTeacher();
        }
        public async Task<TeacherModel> Create(TeacherModel data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            connectTeacherCollection.InsertOne(data);
            return data;
        }

        public async Task<bool> Edit(TeacherModel TeacherData)
        {
            if (TeacherData == null)
            {
                throw new ArgumentNullException("item");
            }
            var def = Builders<TeacherModel>.Update
                .Set(x => x.teacherId, TeacherData.teacherId)
                .Set(x => x.teacherName, TeacherData.teacherName)
                .Set(x => x.teacherTel, TeacherData.teacherTel)
                .Set(x => x.subjectTaught, TeacherData.subjectTaught);
            connectTeacherCollection.UpdateOne(x => x.teacherId == TeacherData.teacherId, def);
            return true;
        }

        public async Task<List<TeacherModel>> Get()
        {
            return connectTeacherCollection.Find(it => true).ToList();
        }

        public async Task<TeacherModel> GetById(string id)
        {
            return connectTeacherCollection.Find(it => it.teacherId == id).FirstOrDefault();
        }

        public void Remove(string TeacherId)
        {
            connectTeacherCollection.DeleteMany(it => it.teacherId == TeacherId);
        }
    }
}
