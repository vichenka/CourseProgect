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
    public class TestService : ITestService
    {
        IUnitOfWork db { get; set; }

        public TestService(IUnitOfWork uow)
        {
            db = uow;
        }

        async Task<TEST> IService<TEST, int>.Add(TEST entity)
        {
            var Test = await db.Test.Add(entity);
            return Test;
        }

        async Task<TEST> IService<TEST, int>.Delete(TEST entity)
        {
            var Test = await db.Test.Delete(entity);
            return Test;
        }

        async Task<IEnumerable<TEST>> IService<TEST, int>.Get()
        {
            var Test = await db.Test.Get();
            return Test;
        }

        async Task<IEnumerable<TEST>> IService<TEST, int>.Get(Func<TEST, bool> predicate)
        {
            var Test = await db.Test.Get(predicate);
            return Test;
        }

        async Task<TEST> IService<TEST, int>.Get(int id)
        {
            var Test = await db.Test.Get(id);
            return Test;
        }

        async Task<TEST> IService<TEST, int>.Update(TEST entity)
        {
            var Test = await db.Test.Update(entity);
            return Test;
        }

        //public void DeleteByIdTest(int test_id)//????????????????
        //{
        //    try
        //    {
        //        //  db.Test.Delete(m => m.ID == test_id).FirstOrDefault();

        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}



        //public IEnumerable<TEST> GetAllTest()
        //{
        //    try
        //    {
        //        return db.Test.GetAll();

        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //public IEnumerable<TEST> GetAllTestByUserId(string user_id)
        //{
        //    try
        //    {
        //        return db.Test.Find(m => m.USER.Id == user_id).ToList();

        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //public List<TEST> GetNameUserByTestId(int test_id)
        //{
        //    try
        //    {
        //        return db.Test.Find(m => m.ID == test_id).ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //public TEST NameTest(int test_id)
        //{
        //    try
        //    {
        //        return db.Test.Find(m => m.ID == test_id);

        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //public TEST NameTestEmpty(string name_test)
        //{
        //    try
        //    {


        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        //public int Take_id_Test_ByName(string name_test)
        //{
        //    try
        //    {


        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        //public IEnumerable<TEST> TestSelectListByAuthor(string author)
        //{
        //    try
        //    {


        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        //public void Update(TEST test)
        //{
        //    try
        //    {


        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}


    }
}
