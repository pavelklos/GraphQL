using GraphQLMutationBasicCRUD.Exceptions;
using GraphQLMutationBasicCRUD.IService;
using GraphQLMutationBasicCRUD.Models;

namespace GraphQLMutationBasicCRUD.Service
{
    public class StudentService : IStudentService
    {
        private IList<Student> _students;

        public StudentService()
        {
            _students = new List<Student>()
            {
                new Student() { StudentId = 1, Name= "Shakib", GroupId = 1 },
                new Student() { StudentId = 2, Name= "Rahat", GroupId = 2 },
                new Student() { StudentId = 3, Name= "Rohit", GroupId = 3 },
                new Student() { StudentId = 4, Name= "Arman", GroupId = 1 },
            };
        }

        public Student Create(CreateStudentInput inputStudent)
        {
            var student = new Student()
            {
                StudentId = _students.Max(x => x.StudentId),
                Name = inputStudent.Name,
                GroupId = inputStudent.GroupId,
            };

            _students.Add(student);

            return student;
        }

        public Student Delete(DeleteStudentInput inputStudent)
        {
            var student = _students.FirstOrDefault(x => x.StudentId == inputStudent.StudentId);

            if (student == null)
            {
                throw new StudentNotFoundException() { StudentId = inputStudent.StudentId };
            }

            _students.Remove(student);

            return student;
        }

        public IQueryable<Student> GetAll()
        {
            return _students.AsQueryable();
        }
    }
}
