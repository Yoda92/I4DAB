using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using Assignment2.TopLayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;


namespace Assignment2.BottomLayerPersistenceLogic.Repositories
{
    public class Repository<EntityType> : IRepository<EntityType> where EntityType : class
    {
        public DbContext Context { get; set; }

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(EntityType entity)
        {
            Context.Set<EntityType>().Add(entity);
        }

        public IEnumerable Find(Expression<Func<EntityType, bool>> lambdaExpression)
        {
            return Context.Set<EntityType>().Where(lambdaExpression);
        }

        public IEnumerable GetAll()
        {
            return Context.Set<EntityType>().ToList();
        }


        public void Remove(EntityType entity)
        {
            Context.Set<EntityType>().Remove(entity);
        }
    }
}