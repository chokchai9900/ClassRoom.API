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
        public IMongoCollection<StudentModel> connectStudentCollection { get; set; }
        public IMongoCollection<TeacherModel> connectTeacherCollection { get; set; }
        public IMongoCollection<ClassRoomModel> connectClassRoomCollection { get; set; }

        public ClassRoomService()
        {
            connectStudentCollection = _dBContext.MongoCollectionStudent();
            connectTeacherCollection = _dBContext.MongoCollectionTeacher();
            connectClassRoomCollection = _dBContext.MongoCollectionClassroom();
        }

        public async Task<bool> AddStudentInClassByClassRoomIdAsync(string classId, string stdId)
        {
            if (stdId == null || classId == null)
            {
                throw new ArgumentNullException("data");
            }
            var classRoom = connectClassRoomCollection.Find(it => it.classRoomId == classId).FirstOrDefault();
            var student = connectStudentCollection.Find(it => it.studentId == stdId).FirstOrDefault();
            var validate = Array.Find(classRoom.classStudent, it => it.studentId == stdId);
            var addindex = classRoom.classStudent.Count();
            if (validate == null)
            {
                classRoom.classStudent[addindex] = student;
                var def = Builders<ClassRoomModel>.Update
                    .Set(x => x.classStudent, classRoom.classStudent);
                connectClassRoomCollection.UpdateOne(it => it.classRoomId == classRoom.classRoomId,def);
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
            var classRoom = connectClassRoomCollection.Find(it => it.classRoomId == classId).FirstOrDefault();
            var teacher = connectTeacherCollection.Find(it => it.teacherId == teacherId).FirstOrDefault();
            var validate = Array.Find(classRoom.classTeacher, it => it.teacherId == teacherId);
            var addindex = classRoom.classTeacher.Count();
            if (validate != null)
            {
                classRoom.classTeacher[addindex] = teacher;
                var def = Builders<ClassRoomModel>.Update
                    .Set(x => x.classTeacher, classRoom.classTeacher);
                connectClassRoomCollection.UpdateOne(it => it.classRoomId == classRoom.classRoomId, def);
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
            connectClassRoomCollection.InsertOne(newRoom);
            return newRoom;
        }
        public async Task<List<ClassRoomModel>> GetClassRoom()
        {
            return connectClassRoomCollection.Find(it => true).ToList();
        }
        public async Task<ClassRoomModel> GetDataByClassRoomId(string id)
        {
            return connectClassRoomCollection.Find(it => it.classRoomId == id).FirstOrDefault();
        }
        public void RemoveClassRoom(string ClassRoomId)
        {
            connectClassRoomCollection.DeleteOne(it => it.classRoomId == ClassRoomId);
        }
    }
}
