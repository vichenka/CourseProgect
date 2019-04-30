using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.BLL.Interfaces
{
    public interface IQuestionService:IService<QUESTION,int>
    {
        Task<QUESTION> GetByQuestId(int quest_id);
        //void DeleteQuestionByTest(int test_id);
        Task<IEnumerable<QUESTION>> IdQuestionByIdTest(int test_id);
        Task<int> QuestionidByText(int test_id, string text);//По ID Теста и тескту вопроса вернуть ид вопроса
        Task<IEnumerable<QUESTION>> QuestionSelectListByIdTest(int test_id);

    }
}
