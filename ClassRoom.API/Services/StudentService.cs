using ClassRoom.API.Interface;
using ClassRoom.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Services
{
    public class StudentService : IPersionManage<StudentModel>
    {
        static readonly DBContext _dBContext = new DBContext();
        public IMongoCollection<StudentModel> connectStudentCollection = _dBContext.MongoCollectionStudent();

        //public StudentService()
        //{
        //    connectStudentCollection = _dBContext.MongoCollectionStudent();
        //}

        public async Task<StudentModel> Create(StudentModel data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            connectStudentCollection.InsertOne(data);
            return data;
        }

        public async Task<bool> Edit(StudentModel stdData)
        {
            if (stdData == null)
            {
                throw new ArgumentNullException("data");
            }
            var def = Builders<StudentModel>.Update
                .Set(x => x.studentId, stdData.studentId)
                .Set(x => x.studentName, stdData.studentName)
                .Set(x => x.studentAge, stdData.studentAge)
                .Set(x => x.studentTel, stdData.studentTel);
            connectStudentCollection.UpdateOne(x => x.studentId == stdData.studentId, def);
            return true;
        }

        public async Task<List<StudentModel>> Get()
        {
            return connectStudentCollection.Find(it => true).ToList();
        }

        public async Task<StudentModel> GetById(string id)
        {
            return connectStudentCollection.Find(it => it.studentId == id).FirstOrDefault();
        }

        public void Remove(string stdId)
        {
            connectStudentCollection.DeleteMany(it => it.studentId == stdId);
        }
    }
}
