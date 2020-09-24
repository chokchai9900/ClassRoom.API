using ClassRoom.API.Interface;
using ClassRoom.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.API.Services
{
    public class DBContext
    {
        public static IMongoCollection<StudentModel> CollectionStudent { get; set; }
        public static IMongoCollection<TeacherModel> CollectionTeacher { get; set; }
        public static IMongoCollection<ClassRoomModel> CollectionClassRoom { get; set; }

        public static void DbConnection()
        {
            var mongo = new MongoClient("mongodb+srv://ccbloodrainz:wK9Il7wsh15rvLTf@cluster0.ymd29.azure.mongodb.net/CheckInClassroom?retryWrites=true&w=majority");
            var database = mongo.GetDatabase("CheckInClassroom");
            CollectionStudent = database.GetCollection<StudentModel>("Student");
            CollectionTeacher = database.GetCollection<TeacherModel>("Teacher");
            CollectionClassRoom = database.GetCollection<ClassRoomModel>("Classroom");
        }

        public IMongoCollection<StudentModel> MongoCollectionStudent()
        {
            DbConnection();
            return CollectionStudent;
        }
        public IMongoCollection<TeacherModel> MongoCollectionTeacher()
        {
            DbConnection();
            return CollectionTeacher;
        }
        public IMongoCollection<ClassRoomModel> MongoCollectionClassroom()
        {
            DbConnection();
            return CollectionClassRoom;
        }
    }
}
