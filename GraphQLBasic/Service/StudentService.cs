using GraphQLBasic.IService;
using GraphQLBasic.Models;

namespace GraphQLBasic.Service
{
    public class StudentService : IStudentService
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new();

            for (int i = 1; i <= 9; i++)
            {
                students.Add(new Student() { StudentId = i, Name = $"Student-{i}", Roll = $"100{i}" });
            }

            return students;
        }
    }
}
