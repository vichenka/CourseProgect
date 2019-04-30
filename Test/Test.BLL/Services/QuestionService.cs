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
    public class QuestionService:IQuestionService
    {
        IUnitOfWork db { get; set; }

        public QuestionService(IUnitOfWork uow)
        {
            db = uow;
        }

        async Task<QUESTION> IService<QUESTION, int>.Add(QUESTION entity)
        {
            var Question = await db.Question.Add(entity);
            return Question;
        }

        async Task<QUESTION> IService<QUESTION, int>.Delete(QUESTION entity)
        {
            var Question = await db.Question.Delete(entity);
            return Question;
        }

        async Task<IEnumerable<QUESTION>> IService<QUESTION, int>.Get()
        {
            var Question = await db.Question.Get();
            return Question;
        }

        async Task<IEnumerable<QUESTION>> IService<QUESTION, int>.Get(Func<QUESTION, bool> predicate)
        {
            var Question = await db.Question.Get(predicate);
            return Question;
        }

        async Task<QUESTION> IService<QUESTION, int>.Get(int id)
        {
            var Question = await db.Question.Get(id);
            return Question;
        }

        async Task<QUESTION> IService<QUESTION, int>.Update(QUESTION entity)
        {
            var Question = await db.Question.Update(entity);
            return Question;
        }

        async Task<QUESTION> IQuestionService.GetByQuestId(int quest_id)
        {
            var Quest = (await db.Question.Get(m => m.ID_QUESTION == quest_id)).ToList()[0];
            return Quest;
        }

        async Task<IEnumerable<QUESTION>> IQuestionService.IdQuestionByIdTest(int test_id)
        {
            var IdQuest = (await db.Question.Get(m => m.ID_TEST == test_id)).ToList();
            return IdQuest;
        }

        async Task<IEnumerable<QUESTION>> IQuestionService.QuestionSelectListByIdTest(int test_id)
        {
            var QuestList = (await db.Question.Get(m => m.ID_TEST == test_id)).ToList();
            return QuestList;
        }

      
        async Task<int> IQuestionService.QuestionidByText(int test_id, string text)
        {
            var QuestionId = (await db.Question.Get(m => m.ID_TEST == test_id && m.QUESTION1 == text)).ToList()[0];
            return QuestionId.ID_QUESTION;
        }
    }
}
