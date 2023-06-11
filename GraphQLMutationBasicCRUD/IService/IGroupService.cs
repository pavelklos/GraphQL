using GraphQLMutationBasicCRUD.Models;

namespace GraphQLMutationBasicCRUD.IService
{
    public interface IGroupService
    {
        IQueryable<Group> GetAll();
    }
}
