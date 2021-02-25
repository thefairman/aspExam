using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class GroupModel : AbstractModel
    {

        public string Name { get; set; }
        public Guid FacultyId { get; set; }

        public FacultyModel Faculty { get; set; }

        public List<StudentModel> Students { get; set; }

        public static IQueryable<Group> IncludeNavigations(IQueryable<Group> query)
        {
            return query.Include(g => g.Faculty);
        }
    }
}
