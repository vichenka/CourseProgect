using System;
using System.Collections.Generic;
using System.Text;
using Test.Models;

namespace Test.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       // IRepository<ApplicationUser,int> Users { get; } ????????????????????
        IRepository<HISTORY, int> History { get; }
        IRepository<POINT, int> Point { get; }
        IRepository<QUESTION,int> Question { get; }
        IRepository<RESULT, int> Result { get; }
        IRepository<TEST,int> Test { get; }
        IRepository<TYPE,int> Type { get; }
        void Save();
    }
}
