﻿
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Gezgineri.Repository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            var affectedRowCount = await _context.SaveChangesAsync();
            return affectedRowCount > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e => e.ID == id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e =>e.ID == id);
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var affectedRowCount = 0;
            var dbSet = await _dbSet.FindAsync(entity.ID);

            _context.Entry(dbSet).CurrentValues.SetValues(entity);
            affectedRowCount = await _context.SaveChangesAsync();

            return affectedRowCount > 0;
        }
    }
}
