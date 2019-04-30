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
    public class TestRepository : IRepository<TEST,int>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEST> _dbSet;

        public TestRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEST>();
            _context.TEST.Load();
        }

        async Task<TEST> IRepository<TEST, int>.Add(TEST entity)
        {
            TEST resTest;
            try
            {
                resTest = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTest = null;
            }
            return resTest;
        }

        async Task<TEST> IRepository<TEST, int>.Delete(TEST entity)
        {
            TEST resTest;
            try
            {
                resTest = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTest = null;
            }
            return resTest;
        }

        async Task<TEST> IRepository<TEST, int>.Get(int id)
        {
            TEST History;
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

        async Task<IEnumerable<TEST>> IRepository<TEST, int>.Get()
        {
            IEnumerable<TEST> hs = await _dbSet.ToListAsync();
            return hs;
        }

        async Task<IEnumerable<TEST>> IRepository<TEST, int>.Get(Func<TEST, bool> predicate)
        {
            IEnumerable<TEST> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<TEST>);
            return cities;
        }

        public IQueryable<TEST> Query()
        {
            return _dbSet;
        }

        async Task<TEST> IRepository<TEST, int>.Update(TEST entity)
        {
            TEST resTest;
            try
            {
                resTest = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTest = null;
            }
            return resTest;
        }
    }
}