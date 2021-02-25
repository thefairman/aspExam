using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class StudentModel : AbstractModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid GroupId { get; set; }

        public GroupModel Group { get; set; }

        public static IQueryable<Student> IncludeNavigations(IQueryable<Student> query)
        {
            return query.Include(g=>g.Group).ThenInclude(f=>f.Faculty);
        }
    }
}
