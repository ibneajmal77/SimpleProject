//-----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" client="ManagementSystem">
//     copy right ManagementSystem.
// </copyright>
//-----------------------------------------------------------------------

namespace Equatorial.PLR.Infrastructure.Repository.UnitOfWork
{
    using Equatorial.PLR.Infrastructure.Repository.GenericRepository;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Unit of work interface
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Register the repository
        /// </summary>
        /// <typeparam name="TEntity">TEntity is the class</typeparam>
        /// <returns>A repository</returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void DetachAllEntities();
        /// <summary>
        /// Save transaction 
        /// </summary>
        /// <returns>Response integer</returns>
        int SaveChanges();

        /// <summary>
        /// Save transaction async
        /// </summary>
        /// <returns>Response integer</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Save transaction async with cancellation token
        /// </summary>
        /// <param name="cancellationToken">A cancellation Token</param>
        /// <returns>Response integer</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
