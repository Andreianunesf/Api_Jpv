using Api.Data.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{

    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        //Delete
        async public Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var select = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                
                if (select == null)
                {
                    return false;
                }
                else
                {
                    _dataset.Remove(select);
                    await _context.SaveChangesAsync();
                    return true;
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Insert
        public async Task<T> InsertAsync(T item) 
        {
            try 
            {
                item.Id = Guid.NewGuid();

                _dataset.Add(item);
                await _context.SaveChangesAsync(); 
            } 
            catch (Exception e)
            {
                throw e;
            } 
            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                var select = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (select == null)
                {
                    return null;
                }
                else
                {
                    return select;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        async public Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Update
        async public Task<T> UpdateAsync(T item)
        {
            try
            {
                var select = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (select == null)
                {
                    return null;
                }
                else {
                    _context.Entry(select).CurrentValues.SetValues(item);
                    await _context.SaveChangesAsync();
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
            return item;
        }
    }
    
}
