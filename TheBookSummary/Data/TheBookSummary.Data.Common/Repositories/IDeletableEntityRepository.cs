namespace TheBookSummary.Data.Common.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using TheBookSummary.Data.Common.Models;

    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

        public IQueryable<TEntity> FindIncluding<TProperty>(
            Expression<Func<TEntity, TProperty>> includeExpression,
            Expression<Func<TEntity, bool>> filter);

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
