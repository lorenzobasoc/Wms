using System.Linq.Expressions;
using Wms.Api.Exceptions;

namespace Wms.Api.Extensions;

public static class LinqExtensions
{
    public static TSource SingleOrThrow<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        string errorCode = null,
        object errorParams = null)
    {
        return source.SingleOrDefault(predicate)
            ?? throw new NotFoundException(errorCode ?? "Resource not found", errorParams);
    }

    public static async Task<TSource> SingleOrThrowAsync<TSource>(
        this IQueryable<TSource> source, 
        Expression<Func<TSource, bool>> predicate,
        string errorCode = null,
        object errorParams = null,
        CancellationToken ct = default)
    {
        return await source.SingleOrDefaultAsync(predicate, ct)
            ?? throw new NotFoundException(errorCode ?? "Resource not found", errorParams);
    }

    public static TSource FirstOrThrow<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        string errorCode = null,
        object errorParams = null)
    {
        return source.FirstOrDefault(predicate)
            ?? throw new NotFoundException(errorCode ?? "Resource not found", errorParams);
    }

    public static async Task<TSource> FirstOrThrowAsync<TSource>(
        this IQueryable<TSource> source, 
        Expression<Func<TSource, bool>> predicate,
        string errorCode = null,
        object errorParams = null,
        CT ct = default)
    {
        return await source.FirstOrDefaultAsync(predicate, ct)
            ?? throw new NotFoundException(errorCode ?? "Resource not found", errorParams);
    }
}

