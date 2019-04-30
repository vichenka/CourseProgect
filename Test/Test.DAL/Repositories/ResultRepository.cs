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
    public class ResultRepository:IRepository<RESULT,int>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<RESULT> _dbSet;

        public ResultRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<RESULT>();
            _context.RESULT.Load();
        }

        async Task<RESULT> IRepository<RESULT, int>.Add(RESULT entity)
        {
            RESULT resResult;
            try
            {
                resResult = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resResult = null;
            }
            return resResult;
        }

        async Task<RESULT> IRepository<RESULT, int>.Delete(RESULT entity)
        {
            RESULT resResult;
            try
            {
                resResult = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resResult = null;
            }
            return resResult;
        }

        async Task<RESULT> IRepository<RESULT, int>.Get(int id)
        {
            RESULT History;
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

        async Task<IEnumerable<RESULT>> IRepository<RESULT, int>.Get()
        {
            IEnumerable<RESULT> hs = await _dbSet.ToListAsync();
            return hs;
        }

        async Task<IEnumerable<RESULT>> IRepository<RESULT, int>.Get(Func<RESULT, bool> predicate)
        {
            IEnumerable<RESULT> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<RESULT>);
            return cities;
        }

        public IQueryable<RESULT> Query()
        {
            return _dbSet;
        }

        async Task<RESULT> IRepository<RESULT, int>.Update(RESULT entity)
        {
            RESULT resResult;
            try
            {
                resResult = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resResult = null;
            }
            return resResult;
        }
    }
}