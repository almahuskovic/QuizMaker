using AutoMapper;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Entities;
using QuizMaker.Model.Requests.QuizQuestions;
using QuizMaker.Model.Requests.Quizzes;
using QuizMaker.Model.Requests.QuizzesQuestions;

namespace QuizMaker.Mapping
{
    public class QuizMakerProfile: Profile
    {
        public QuizMakerProfile()
        {
            CreateMap<Quiz, QuizDto>().ReverseMap();
            CreateMap<QuizUpsertRequest, Quiz>();

            CreateMap<QuizQuestion, QuizQuestionDto>().ReverseMap();
            CreateMap<QuizQuestionUpsertRequest, QuizQuestion>();

            CreateMap<QuizzesQuestions, QuizzesQuestionsDto>().ReverseMap();
            CreateMap<QuizzesQuestionsUpsertRequest, QuizzesQuestions>();
        }
    }
}
