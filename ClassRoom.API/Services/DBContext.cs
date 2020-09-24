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
        public static IMongoCollection<StudentModel> collectionStudent { get; set; }
        public static IMongoCollection<TeacherModel> collectionTeacher { get; set; }
        public static IMongoCollection<ClassRoomModel> collectionClassRoom { get; set; }

        public static void dbConnection()
        {
            var mongo = new MongoClient("mongodb+srv://ccbloodrainz:wK9Il7wsh15rvLTf@cluster0.ymd29.azure.mongodb.net/CheckInClassroom?retryWrites=true&w=majority");
            var database = mongo.GetDatabase("CheckInClassroom");
            collectionStudent = database.GetCollection<StudentModel>("Student");
            collectionTeacher = database.GetCollection<TeacherModel>("Teacher");
            collectionClassRoom = database.GetCollection<ClassRoomModel>("Classroom");
        }

        public IMongoCollection<StudentModel> MongoCollectionStudent()
        {
            dbConnection();
            return collectionStudent;
        }
        public IMongoCollection<TeacherModel> MongoCollectionTeacher()
        {
            dbConnection();
            return collectionTeacher;
        }
        public IMongoCollection<ClassRoomModel> MongoCollectionClassroom()
        {
            dbConnection();
            return collectionClassRoom;
        }
    }
}
