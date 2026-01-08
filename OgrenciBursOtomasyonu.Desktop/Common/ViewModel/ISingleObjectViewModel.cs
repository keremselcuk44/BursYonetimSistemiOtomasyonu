using System;

namespace OgrenciBursOtomasyonu.Desktop.Common.ViewModel
{
    /// <summary>
    /// Represents a View Model for a single object view that implements CRUD operations with a single entity.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    public interface ISingleObjectViewModel<TEntity>
    {
        /// <summary>
        /// Determines whether the entity is new.
        /// </summary>
        bool IsNew();
    }

    /// <summary>
    /// Represents a View Model for a single object view that implements CRUD operations with a single entity.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    public interface ISingleObjectViewModel<TEntity, TPrimaryKey> : ISingleObjectViewModel<TEntity>
    {
        /// <summary>
        /// The entity primary key.
        /// </summary>
        TPrimaryKey PrimaryKey { get; }
    }
}

