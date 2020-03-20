using System;
using System.Collections;
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
            throw new NotImplementedException();
        }

        public IEnumerable Find(Expression<Func<EntityType, bool>> lambdaExpression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetAll()
        {
            throw new NotImplementedException();
        }

        public EntityType GetByIntegerID(uint ID)
        {
            throw new NotImplementedException();
        }

        public EntityType GetByStringID(uint ID)
        {
            throw new NotImplementedException();
        }

        public void Remove(EntityType entity)
        {
            throw new NotImplementedException();
        }
    }
}