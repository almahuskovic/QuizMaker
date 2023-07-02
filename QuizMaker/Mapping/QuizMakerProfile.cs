using AutoMapper;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Entities;

namespace QuizMaker.Mapping
{
    public class QuizMakerProfile: Profile
    {
        public QuizMakerProfile()
        {
            CreateMap<Quiz, QuizDto>().ReverseMap();
            CreateMap<QuizQuestion, QuizQuestionDto>().ReverseMap();
        }
    }
}
