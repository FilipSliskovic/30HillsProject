using _30HillsProject.DataAccess.Exceptions;
using _30HillsProject.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.DataAccess.Extensions
{
    public static class DBSetExtensions
    {
        public static void Deactivate(this DbContext context, Entity entity)
        {
            entity.IsActive = false;
            entity.DeletedAt = DateTime.UtcNow;
            context.Entry(entity).State = EntityState.Modified;

        }

        public static void Deactivate<T>(this DbContext context, int id)
            where T : Entity
        {
            var itemToDeactivate = context.Set<T>().Find(id);
            if (itemToDeactivate == null)
            {
                throw new EntityNotFoundException();
            }
            itemToDeactivate.IsActive = false;
            itemToDeactivate.DeletedAt = DateTime.UtcNow;
        }

        public static void Deactivate<T>(this DbContext context, IEnumerable<int> ids)
            where T : Entity
        {
            var toDeactivate = context.Set<T>().Where(x => ids.Contains(x.Id));

            foreach (var d in toDeactivate)
            {
                d.IsActive = false;
                d.DeletedAt = DateTime.UtcNow;
            }

        }
    }
}
