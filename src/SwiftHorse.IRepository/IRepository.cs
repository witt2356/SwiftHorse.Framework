﻿namespace SwiftHorse
{
    /// <summary>
    /// Root repository interface
    /// </summary>
    public interface IRepository
    {

    }

    /// <summary>
    /// Entity repository interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial interface IRepository<TEntity> : IRepository
    {
    }

    /// <summary>
    /// Entity repository interface with pk
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPKey"></typeparam>
    public interface IRepository<TEntity, TPKey> : IRepository<TEntity>
    {
    }
}
