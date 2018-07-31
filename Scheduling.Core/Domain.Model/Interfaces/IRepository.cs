using System.Collections.Generic;

namespace GenericRepositoryDemo
{
    public class NonRoot : IEntity
    {
        public NonRoot()
        {
            //Repository<NonRoot> nonRootRepo = new Repository<NonRoot>();
        }
    }
    
    public class Root : IAggregateRoot
    {
        public Root()
        {
            Repository<Root> rootRepo = new Repository<Root>();
        }
        
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntity> List()
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
    public class RootRepository : IRepository<Root>
    {
        public void Delete(Root entity)
        {
            throw new System.NotImplementedException();
        }

        public Root GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Root entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Root> List()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Root entity)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        IEnumerable<TEntity> List();
        TEntity GetById(int id);
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
    }

    /// <summary>
    /// Marker interface
    /// </summary>
    public interface IAggregateRoot : IEntity { }

    public interface IEntity { }
}