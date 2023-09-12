using System.Linq.Expressions;

namespace TodoList.Application.Common.Interfaces;

public interface IRepository<T> where T : class
{
    // 新增实体（Create）
    // Create相关操作接口
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

    // 更新实体（Update）
    // Update相关操作接口
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

    // 删除实体（Delete）
    // Delete相关操作接口，这里根据key删除对象的接口需要用到一个获取对象的方法
    ValueTask<T?> GetAsync(object key);
    Task DeleteAsync(object key);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    // 省略其他...
    // 1. 查询基础操作接口
    IQueryable<T> GetAsQueryable();
    IQueryable<T> GetAsQueryable(ISpecification<T> spec);

    // 2. 查询数量相关接口
    int Count(ISpecification<T>? spec = null);
    int Count(Expression<Func<T, bool>> condition);
    Task<int> CountAsync(ISpecification<T>? spec);

    // 3. 查询存在性相关接口
    bool Any(ISpecification<T>? spec);
    bool Any(Expression<Func<T, bool>>? condition = null);

    // 4. 根据条件获取原始实体类型数据相关接口
    Task<T?> GetAsync(Expression<Func<T, bool>> condition);
    Task<IReadOnlyList<T>> GetAsync();
    Task<IReadOnlyList<T>> GetAsync(ISpecification<T>? spec);

    // 5. 根据条件获取映射实体类型数据相关接口，涉及到Group相关操作也在其中，使用selector来传入映射的表达式
    TResult? SelectFirstOrDefault<TResult>(ISpecification<T>? spec, Expression<Func<T, TResult>> selector);
    Task<TResult?> SelectFirstOrDefaultAsync<TResult>(ISpecification<T>? spec, Expression<Func<T, TResult>> selector);

    Task<IReadOnlyList<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector);
    Task<IReadOnlyList<TResult>> SelectAsync<TResult>(ISpecification<T>? spec, Expression<Func<T, TResult>> selector);
    Task<IReadOnlyList<TResult>> SelectAsync<TGroup, TResult>(Expression<Func<T, TGroup>> groupExpression, Expression<Func<IGrouping<TGroup, T>, TResult>> selector, ISpecification<T>? spec = null);

}