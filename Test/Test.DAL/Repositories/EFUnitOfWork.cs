
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Test.DAL.Interfaces;
using Test.Models;

namespace Test.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
      //  private UserRepository userRepository;
        private HistoryRepository historyRepository;
        private PointRepository pointRepository;
        private QuestionRepository questionRepository;
        private ResultRepository resultRepository;
        private TestRepository testRepository;
        private TypeRepository typeRepository;

        public EFUnitOfWork(DbContextOptions<ApplicationDbContext> ortions)
        {
            db = new ApplicationDbContext(ortions); //????????????????????
        }

        public IRepository<HISTORY,int> History
        {
            get
            {
                if (historyRepository == null)
                    historyRepository = new HistoryRepository(db);
                return historyRepository;
            }
        }

        public IRepository<POINT,int> Point
        {
            get
            {
                if (pointRepository == null)
                    pointRepository = new PointRepository(db);
                return pointRepository;
            }
        }

        public IRepository<QUESTION,int> Question
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(db);
                return questionRepository;
            }
        }

        public IRepository<RESULT, int> Result
        {
            get
            {
                if (resultRepository == null)
                    resultRepository = new ResultRepository(db);
                return resultRepository;
            }
        }

        public IRepository<TEST,int> Test
        {
            get
            {
                if (testRepository == null)
                   testRepository = new TestRepository(db);
                return testRepository;
            }
        }

        public IRepository<TYPE,int> Type
        {
            get
            {
                if (typeRepository == null)
                    typeRepository = new TypeRepository(db);
                return typeRepository;
            }
        }

        private bool disposed = false;
       
        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
