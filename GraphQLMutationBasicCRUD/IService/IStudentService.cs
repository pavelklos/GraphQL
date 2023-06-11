using GraphQLMutationBasicCRUD.Models;

namespace GraphQLMutationBasicCRUD.IService
{
    public interface IStudentService
    {
        IQueryable<Student> GetAll();
        Student Create(CreateStudentInput inputStudent);
        Student Delete(DeleteStudentInput inputStudent);
    }
}
