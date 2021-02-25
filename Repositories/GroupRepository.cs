using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class GroupRepository : DbRepository<Group>, IGroupRepository
    {
        public GroupRepository(DbContext context) : base(context)
        {
        }
    }
}
