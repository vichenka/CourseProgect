using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.BLL.Interfaces;
using Test.DAL.Interfaces;
using Test.Models;

namespace Test.BLL.Services
{
   public class PointService:IPointService
    {
        IUnitOfWork db { get; set; }

        public PointService(IUnitOfWork uow)
        {
            db = uow;
        }

        async Task<POINT> IService<POINT, int>.Add(POINT entity)
        {
            var Point = await db.Point.Add(entity);
            return Point;
        }

        async Task<POINT> IService<POINT, int>.Delete(POINT entity)
        {
            var Point = await db.Point.Delete(entity);
            return Point;
        }

        async Task<IEnumerable<POINT>> IService<POINT, int>.Get()
        {
            var Point = await db.Point.Get();
            return Point;
        }

        async Task<IEnumerable<POINT>> IService<POINT, int>.Get(Func<POINT, bool> predicate)
        {
            var Point = await db.Point.Get(predicate);
            return Point;
        }

        async Task<POINT> IService<POINT, int>.Get(int id)
        {
            var Point = await db.Point.Get(id);
            return Point;
        }

        async Task<POINT> IService<POINT, int>.Update(POINT entity)
        {
            var Point = await db.Point.Update(entity);
            return Point;
        }

             
    }
}
