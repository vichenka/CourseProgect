using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.BLL.Interfaces;
using Test.DAL.Interfaces;
using Test.Models;

namespace Test.BLL.Services
{
   public class TypeService:ITypeService
    {
        IUnitOfWork db { get; set; }

        public TypeService(IUnitOfWork uow)
        {
            db = uow;
        }

        async Task<TYPE> IService<TYPE, int>.Add(TYPE entity)
        {
            var Type = await db.Type.Add(entity);
            return Type;
        }

        async Task<TYPE> IService<TYPE, int>.Delete(TYPE entity)
        {
            var Type = await db.Type.Delete(entity);
            return Type;
        }

        async Task<IEnumerable<TYPE>> IService<TYPE, int>.Get()
        {
            var Type = await db.Type.Get();
            return Type;
        }

        async Task<IEnumerable<TYPE>> IService<TYPE, int>.Get(Func<TYPE, bool> predicate)
        {
            var Type = await db.Type.Get(predicate);
            return Type;
        }

        async Task<TYPE> IService<TYPE, int>.Get(int id)
        {
            var Type = await db.Type.Get(id);
            return Type;
        }

        async Task<TYPE> IService<TYPE, int>.Update(TYPE entity)
        {
            var Type = await db.Type.Update(entity);
            return Type;
        }

    }
}
