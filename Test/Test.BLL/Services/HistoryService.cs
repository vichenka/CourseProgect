using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.BLL.Interfaces;
using Test.DAL.Interfaces;
using Test.Models;

namespace Test.BLL.Services
{
    public class HistoryService : IHistoryService
    {
        IUnitOfWork db { get; set; }

        public HistoryService(IUnitOfWork uow)
        {
            db = uow;
        }

        async Task<HISTORY> IService<HISTORY, int>.Add(HISTORY entity)
        {
            var History = await db.History.Add(entity);
            return History;
        }

        async Task<HISTORY> IService<HISTORY, int>.Delete(HISTORY entity)
        {
            var History = await db.History.Delete(entity);
            return History;
        }

        async Task<IEnumerable<HISTORY>> IService<HISTORY, int>.Get()
        {
            var History = await db.History.Get();
            return History;
        }

        async Task<IEnumerable<HISTORY>> IService<HISTORY, int>.Get(Func<HISTORY, bool> predicate)
        {
            var History = await db.History.Get(predicate);
            return History;
        }

        async Task<HISTORY> IService<HISTORY, int>.Get(int id)
        {
            var History = await db.History.Get(id);
            return History;
        }

        async Task<HISTORY> IService<HISTORY, int>.Update(HISTORY entity)
        {
            var History = await db.History.Update(entity);
            return History;
        }
    }
}
