using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolLocker.Core.Contracts.Persistence;

namespace SchoolLocker.Persistence
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _dbContext;
    private bool _disposed;

    public UnitOfWork()
    {
      _dbContext = new ApplicationDbContext();
      BookingRepository = new BookingRepository(_dbContext);
      LockerRepository = new LockerRepository(_dbContext);
      PupilRepository = new PupilRepository(_dbContext);
    }

    public IBookingRepository BookingRepository { get; }

    public ILockerRepository LockerRepository { get; }
    public IPupilRepository PupilRepository { get; }

    /// <summary>
    /// Repository-übergreifendes Speichern der Änderungen
    /// </summary>
    public Task<int> SaveChangesAsync()
    {
      var entities = _dbContext.ChangeTracker.Entries()
          .Where(entity => entity.State == EntityState.Added
                           || entity.State == EntityState.Modified)
          .Select(e => e.Entity);
      foreach (var entity in entities)
      {
        ValidateEntity(entity);
      }
      return _dbContext.SaveChangesAsync();
    }


    /// <summary>
    /// Validierungen auf DbContext-Ebene
    /// </summary>
    /// <param name="entity"></param>
    private void ValidateEntity(object entity)
    {
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!_disposed)
      {
        if (disposing)
        {
          _dbContext.Dispose();
        }
      }
      _disposed = true;
    }

    public async Task DeleteDatabaseAsync()
    {
      await _dbContext.Database.EnsureDeletedAsync();
    }

    public async Task MigrateDatabaseAsync()
    {
      await _dbContext.Database.MigrateAsync();
    }

  }


}
