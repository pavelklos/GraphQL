using GraphQLMutationBasicCRUD.IService;
using GraphQLMutationBasicCRUD.Models;

namespace GraphQLMutationBasicCRUD.Service
{
    public class GroupService : IGroupService
    {
        private IList<Group> _groups;

        public GroupService()
        {
            _groups = new List<Group>()
            {
                new Group() { GroupId = 1, Name= "Science", ShortName = "SC" },
                new Group() { GroupId = 2, Name= "Commerce", ShortName = "COM" },
                new Group() { GroupId = 3, Name= "Arts", ShortName = "AR" },
            };
        }

        public IQueryable<Group> GetAll()
        {
            return _groups.AsQueryable();
        }
    }
}
