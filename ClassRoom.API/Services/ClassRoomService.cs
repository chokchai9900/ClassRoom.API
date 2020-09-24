using ClassRoom.API.Interface;
using ClassRoom.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ClassRoom.API.Services
{
    public class ClassRoomService : IClassRoomRepository<ClassRoomModel>
    {
        static readonly DBContext _dBContext = new DBContext();
        public IMongoCollection<StudentModel> ConnectStudentCollection { get; set; }
        public IMongoCollection<TeacherModel> ConnectTeacherCollection { get; set; }
        public IMongoCollection<ClassRoomModel> ConnectClassRoomCollection { get; set; }

        public static DBContext DBContext => _dBContext;

        public ClassRoomService()
        {
            ConnectStudentCollection = _dBContext.MongoCollectionStudent();
            ConnectTeacherCollection = _dBContext.MongoCollectionTeacher();
            ConnectClassRoomCollection = _dBContext.MongoCollectionClassroom();
        }

        public async Task<bool> AddStudentInClassByClassRoomIdAsync(string classId, string stdId)
        {
            if (stdId == null || classId == null)
            {
                throw new ArgumentNullException("data");
            }
            var classRoom = ConnectClassRoomCollection.Find(it => it.classRoomId == classId).FirstOrDefault();
            var student = ConnectStudentCollection.Find(it => it.studentId == stdId).FirstOrDefault();
            var validate = Array.Find(classRoom.classStudent, it => it.studentId == stdId);
            var addindex = classRoom.classStudent.Count();
            if (validate == null)
            {
                classRoom.classStudent[addindex] = student;
                var def = Builders<ClassRoomModel>.Update
                    .Set(x => x.classStudent, classRoom.classStudent);
                ConnectClassRoomCollection.UpdateOne(it => it.classRoomId == classRoom.classRoomId,def);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> AddTeacherInClassByClassRoomId(string classId, string teacherId)
        {
            if (teacherId == null || classId == null)
            {
                throw new ArgumentNullException("data");
            }
            var classRoom = ConnectClassRoomCollection.Find(it => it.classRoomId == classId).FirstOrDefault();
            var teacher = ConnectTeacherCollection.Find(it => it.teacherId == teacherId).FirstOrDefault();
            var validate = Array.Find(classRoom.classTeacher, it => it.teacherId == teacherId);
            var addindex = classRoom.classTeacher.Count();
            if (validate != null)
            {
                classRoom.classTeacher[addindex] = teacher;
                var def = Builders<ClassRoomModel>.Update
                    .Set(x => x.classTeacher, classRoom.classTeacher);
                ConnectClassRoomCollection.UpdateOne(it => it.classRoomId == classRoom.classRoomId, def);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ClassRoomModel> CreateClassRoom(string classroomId, string classroomName)
        {
            var newRoom = new ClassRoomModel()
            {
                classRoomId = classroomId,
                classRoomName = classroomName,
                classStudent = null,
                classTeacher = null
            };
            ConnectClassRoomCollection.InsertOne(newRoom);
            return newRoom;
        }
        public async Task<List<ClassRoomModel>> GetClassRoom()
        {
            return ConnectClassRoomCollection.Find(it => true).ToList();
        }
        public async Task<ClassRoomModel> GetDataByClassRoomId(string id)
        {
            return ConnectClassRoomCollection.Find(it => it.classRoomId == id).FirstOrDefault();
        }
        public void RemoveClassRoom(string ClassRoomId)
        {
            ConnectClassRoomCollection.DeleteOne(it => it.classRoomId == ClassRoomId);
        }
    }
}
