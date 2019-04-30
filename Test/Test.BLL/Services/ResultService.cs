using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BLL.Interfaces;
using Test.DAL.Interfaces;
using Test.Models;

namespace Test.BLL.Services
{
   public class ResultService:IResultService
    {
        IUnitOfWork db { get; set; }

        public ResultService(IUnitOfWork uow)
        {
            db = uow;
        }

        async Task<RESULT> IService<RESULT, int>.Add(RESULT entity)
        {
            var Result = await db.Result.Add(entity);
            return Result;
        }

        async Task<RESULT> IService<RESULT, int>.Delete(RESULT entity)
        {
            var Result = await db.Result.Delete(entity);
            return Result;
        }

        async Task<IEnumerable<RESULT>> IService<RESULT, int>.Get()
        {
            var Result = await db.Result.Get();
            return Result;
        }

        async Task<IEnumerable<RESULT>> IService<RESULT, int>.Get(Func<RESULT, bool> predicate)
        {
            var Result = await db.Result.Get(predicate);
            return Result;
        }

        async Task<RESULT> IService<RESULT, int>.Get(int id)
        {
            var Result = await db.Result.Get(id);
            return Result;
        }

        async Task<RESULT> IService<RESULT, int>.Update(RESULT entity)
        {
            var Result = await db.Result.Update(entity);
            return Result;
        }

        async Task<RESULT> IResultService.GetTextResByResId(int result_id)
        {
            var Res = (await db.Result.Get(m => m.ID_Result == result_id)).ToList()[0];
            return Res;
        }
    }
}
