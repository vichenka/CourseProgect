using Test.DAL.Interfaces;
using Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DAL.Repositories
{
    public class HistoryRepository : IRepository<HISTORY,int>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<HISTORY> _dbSet;

        public HistoryRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<HISTORY>();
            _context.HISTORY.Load();
 
        }

       async Task<HISTORY> IRepository<HISTORY,int>.Add(HISTORY entity)
        {
            HISTORY resHistory;
            try
            {
                resHistory = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resHistory = null;
            }
            return resHistory;
        }

        async Task<HISTORY> IRepository<HISTORY, int>.Delete(HISTORY entity)
        {
            HISTORY resHistory;
            try
            {
                resHistory = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resHistory = null;
            }
            return resHistory;
        }
 
        async Task<HISTORY> IRepository<HISTORY, int>.Get(int id)
        {
            HISTORY History;
            try
            {

                History = await _dbSet.FindAsync(id);
            }
            catch
            {
                History = null;
            }
            return History;
        }

        async Task<IEnumerable<HISTORY>> IRepository<HISTORY, int>.Get()
        {
            IEnumerable<HISTORY> hs = await _dbSet.ToListAsync();
            return hs;
        }

        async Task<IEnumerable<HISTORY>> IRepository<HISTORY, int>.Get(Func<HISTORY,bool> predicate)
        {
            IEnumerable<HISTORY> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<HISTORY>);
            return cities;
        }

        public IQueryable<HISTORY> Query()
        {
            return _dbSet;
        }

        async Task<HISTORY> IRepository<HISTORY,int>.Update(HISTORY entity)
        {
            HISTORY resHistory;
            try
            {
                resHistory = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resHistory = null;
            }
            return resHistory;
        }
        
      
    }
}