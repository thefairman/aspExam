using Context;
using Domain;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FacultyRepository : DbRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(DbContext context) : base(context)
        {
        }
    }
}
