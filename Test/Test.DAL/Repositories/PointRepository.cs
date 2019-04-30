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
    public class PointRepository : IRepository<POINT,int>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<POINT> _dbSet;

        public PointRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<POINT>();
            _context.POINT.Load();
        }

        async Task<POINT> IRepository<POINT, int>.Add(POINT entity)
        {
            POINT resPoint;
            try
            {
                resPoint = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resPoint = null;
            }
            return resPoint;
        }

        async Task<POINT> IRepository<POINT, int>.Delete(POINT entity)
        {
            POINT resPoint;
            try
            {
                resPoint = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resPoint = null;
            }
            return resPoint;
        }

        async Task<POINT> IRepository<POINT, int>.Get(int id)
        {
            POINT Point;
            try
            {

                Point = await _dbSet.FindAsync(id);
            }
            catch
            {
                Point = null;
            }
            return Point;
        }

        async Task<IEnumerable<POINT>> IRepository<POINT, int>.Get()
        {
            IEnumerable<POINT> hs = await _dbSet.ToListAsync();
            return hs;
        }

        async Task<IEnumerable<POINT>> IRepository<POINT, int>.Get(Func<POINT, bool> predicate)
        {
            IEnumerable<POINT> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<POINT>);
            return cities;
        }

        public IQueryable<POINT> Query()
        {
            return _dbSet;
        }

        async Task<POINT> IRepository<POINT, int>.Update(POINT entity)
        {
            POINT resPoint;
            try
            {
                resPoint = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resPoint = null;
            }
            return resPoint;
        }


    }
}