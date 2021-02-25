using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Helpers;

namespace WebApp.Models
{
    public abstract class AbstractModel
    {
        public Guid Id { get; set; }

        public static IQueryable<TEntity> GetModelsFromRepository<TEntity>(IQueryable<TEntity> qurable, PaginatorModel paginator = null)
            where TEntity : class, IDbEntity
        {
            if (paginator != null && paginator.Page > 0 && paginator.Rows > 0)
                qurable = qurable.Skip((paginator.Page - 1) * paginator.Rows)
                .Take(paginator.Rows);
            return qurable;
        }
    }
}
