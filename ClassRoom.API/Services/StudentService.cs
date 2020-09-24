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
        private IMongoCollection<StudentModel> connectStudentCollection = DBContext.MongoCollectionStudent();

        public static DBContext DBContext => _dBContext;

        public IMongoCollection<StudentModel> ConnectStudentCollection { get => connectStudentCollection; set => connectStudentCollection = value; }

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
            ConnectStudentCollection.InsertOne(data);
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
            ConnectStudentCollection.UpdateOne(x => x.studentId == stdData.studentId, def);
            return true;
        }

        public async Task<List<StudentModel>> Get()
        {
            return ConnectStudentCollection.Find(it => true).ToList();
        }

        public async Task<StudentModel> GetById(string id)
        {
            return ConnectStudentCollection.Find(it => it.studentId == id).FirstOrDefault();
        }

        public void Remove(string stdId)
        {
            ConnectStudentCollection.DeleteMany(it => it.studentId == stdId);
        }
    }
}
