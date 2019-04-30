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
    public class QuestionRepository:IRepository<QUESTION,int>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<QUESTION> _dbSet;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<QUESTION>();
            _context.QUESTION.Load();
        }

        async Task<QUESTION> IRepository<QUESTION, int>.Add(QUESTION entity)
        {
            QUESTION resQuestion;
            try
            {
                resQuestion = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resQuestion = null;
            }
            return resQuestion;
        }

        async Task<QUESTION> IRepository<QUESTION, int>.Delete(QUESTION entity)
        {
            QUESTION resQuestion;
            try
            {
                resQuestion = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resQuestion = null;
            }
            return resQuestion;
        }

        async Task<QUESTION> IRepository<QUESTION, int>.Get(int id)
        {
            QUESTION Question;
            try
            {

                Question = await _dbSet.FindAsync(id);
            }
            catch
            {
                Question = null;
            }
            return Question;
        }

        async Task<IEnumerable<QUESTION>> IRepository<QUESTION, int>.Get()
        {
            IEnumerable<QUESTION> hs = await _dbSet.ToListAsync();
            return hs;
        }

        async Task<IEnumerable<QUESTION>> IRepository<QUESTION, int>.Get(Func<QUESTION, bool> predicate)
        {
            IEnumerable<QUESTION> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<QUESTION>);
            return cities;
        }

        public IQueryable<QUESTION> Query()
        {
            return _dbSet;
        }

        async Task<QUESTION> IRepository<QUESTION, int>.Update(QUESTION entity)
        {
            QUESTION resQuestion;
            try
            {
                resQuestion = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resQuestion = null;
            }
            return resQuestion;
        }
    }
}