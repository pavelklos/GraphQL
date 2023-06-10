using GraphQLBasic.IService;

namespace GraphQLBasic.Models
{
    public class Query
    {
        IStudentService? _studentService = null;

        public Query(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public List<Student> Students => _studentService.GetStudents();
    }
}
