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
    public class TypeRepository : IRepository<TYPE,int>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TYPE> _dbSet;

        public TypeRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TYPE>();
            _context.TYPE.Load();
        }

        async Task<TYPE> IRepository<TYPE, int>.Add(TYPE entity)
        {
            TYPE resType;
            try
            {
                resType = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resType = null;
            }
            return resType;
        }

        async Task<TYPE> IRepository<TYPE, int>.Delete(TYPE entity)
        {
            TYPE resType;
            try
            {
                resType = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resType = null;
            }
            return resType;
        }

        async Task<TYPE> IRepository<TYPE, int>.Get(int id)
        {
            TYPE History;
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

        async Task<IEnumerable<TYPE>> IRepository<TYPE, int>.Get()
        {
            IEnumerable<TYPE> hs = await _dbSet.ToListAsync();
            return hs;
        }

        async Task<IEnumerable<TYPE>> IRepository<TYPE, int>.Get(Func<TYPE, bool> predicate)
        {
            IEnumerable<TYPE> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<TYPE>);
            return cities;
        }

        public IQueryable<TYPE> Query()
        {
            return _dbSet;
        }

        async Task<TYPE> IRepository<TYPE, int>.Update(TYPE entity)
        {
            TYPE resType;
            try
            {
                resType = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resType = null;
            }
            return resType;
        }

        public Task<IEnumerable<TYPE>> Get(Func<TYPE, int> predicate)
        {
            throw new NotImplementedException();
        }
    }
}