using RestaurantDemo.DDD.SpecificationPattern.DB.Entities;
using System.Linq.Expressions;

namespace RestaurantDemo.DDD.SpecificationPattern.Specifications;

public abstract class Specification<TEntity> where TEntity : BaseEntity
{
    public bool IsSplitQuery { get; protected set; }
    public Expression<Func<TEntity, bool>>? Criteria { get; init; }
    public List<Expression<Func<TEntity, object>>> IncludeExpression { get; init; }
    public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }
    public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

    protected Specification(Expression<Func<TEntity, bool>>? criteria)
    {
        Criteria = criteria;
        IncludeExpression = new();
    }

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        IncludeExpression.Add(includeExpression);
    }

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        OrderByExpression = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
    {
        OrderByDescendingExpression = orderByDescendingExpression;
    }
}