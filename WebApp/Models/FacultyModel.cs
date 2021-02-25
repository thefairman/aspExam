using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class FacultyModel : AbstractModel
    {
        public string Name { get; set; }

        public List<GroupModel> Groups { get; set; }

        internal static IQueryable<Faculty> IncludeNavigations(IQueryable<Faculty> query)
        {
            return query.Include(g => g.Groups);
        }
    }
}
