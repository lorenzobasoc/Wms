using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wms.Api.DataAccess;

public static class ModelBuilderExtension
{
    public static void OwnsOneJson<TEntity, TNestedEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, TNestedEntity>> oneSelector)
            where TEntity : class
            where TNestedEntity : class
    {
        builder.OwnsOne(oneSelector, ne => ne.ToJson());
    }

    public static void OwnsManyJson<TEntity, TNestedEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, IEnumerable<TNestedEntity>>> manySelector)
            where TEntity : class
            where TNestedEntity : class
    {
        builder.OwnsMany(manySelector, ne => ne.ToJson());
    }

    public static void OneToOne<TMainEntity, TDependentEntity>(
        this ModelBuilder builder,
        Expression<Func<TMainEntity, TDependentEntity>> dependentSelector,
        Expression<Func<TDependentEntity, TMainEntity>> mainSelector)
            where TMainEntity : class
            where TDependentEntity : class
    {
        builder
            .Entity<TDependentEntity>()
            .HasOne(mainSelector)
            .WithOne(dependentSelector)
            .OnDelete(DeleteBehavior.NoAction);
    }

    public static void OneToMany<TOneEntity, TManyEntity>(
        this ModelBuilder builder,
        Expression<Func<TOneEntity, IEnumerable<TManyEntity>>> manySelector,
        Expression<Func<TManyEntity, TOneEntity>> oneSelector)
            where TOneEntity : class
            where TManyEntity : class
    {
        builder
            .Entity<TManyEntity>()
            .HasOne(oneSelector)
            .WithMany(manySelector)
            .OnDelete(DeleteBehavior.NoAction);
    }

    public static void ManyToMany<TEntity1, TBridgeEntity, TEntity2>(
        this ModelBuilder builder,
        Expression<Func<TBridgeEntity, TEntity1>> toEntity1Selector,
        Expression<Func<TEntity1, IEnumerable<TBridgeEntity>>> fromEntity1Selector,
        Expression<Func<TBridgeEntity, TEntity2>> toEntity2Selector,
        Expression<Func<TEntity2, IEnumerable<TBridgeEntity>>> fromEntity2Selector)
            where TEntity1 : class
            where TBridgeEntity : class
            where TEntity2 : class
    {
        var e = builder.Entity<TBridgeEntity>(e => {
            e.HasOne(toEntity1Selector).WithMany(fromEntity1Selector).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(toEntity2Selector).WithMany(fromEntity2Selector).OnDelete(DeleteBehavior.NoAction);
        });
    }

    public static void ManyToMany<TEntity1, TBridgeEntity, TEntity2>(
        this ModelBuilder builder,
        Expression<Func<TBridgeEntity, object>> keySelector,
        Expression<Func<TBridgeEntity, TEntity1>> toEntity1Selector,
        Expression<Func<TEntity1, IEnumerable<TBridgeEntity>>> fromEntity1Selector,
        Expression<Func<TBridgeEntity, TEntity2>> toEntity2Selector,
        Expression<Func<TEntity2, IEnumerable<TBridgeEntity>>> fromEntity2Selector)
            where TEntity1 : class
            where TBridgeEntity : class
            where TEntity2 : class
    {
        var e = builder.Entity<TBridgeEntity>(e => {
            e.HasKey(keySelector);
            e.HasOne(toEntity1Selector).WithMany(fromEntity1Selector).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(toEntity2Selector).WithMany(fromEntity2Selector).OnDelete(DeleteBehavior.NoAction);
        });
    }
}
