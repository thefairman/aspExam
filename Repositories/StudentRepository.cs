using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class StudentRepository : DbRepository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }
    }
}
