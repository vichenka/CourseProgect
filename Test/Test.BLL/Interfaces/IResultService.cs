using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.BLL.Interfaces
{
   public interface IResultService:IService<RESULT,int>
    {
        //void DeleteResultBiIdTest(int test_id);
        //IEnumerable<RESULT> IdQResultIdTest(int test_id);
        //IEnumerable<RESULT> IdTestByIdRes(int result_id);//вернуть все идрезалт принадлежащих юзеру,потом ридером читать каждый идрезалт и возвращать по нему назвние теста
        //IEnumerable<RESULT> ShowResult(int test_id, int ball);
        Task<RESULT> GetTextResByResId(int result_id);
        //int ResultidByText(int test_id, string text);//По idTest и тексту результата получить его id


    }
}
