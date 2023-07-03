using Microsoft.EntityFrameworkCore;
using QuizMaker.Model.Entities;
using System;
using System.Linq;

namespace QuizMaker
{
    public class SetupService
    {
        public void Init(Context context)
        {
            context.Database.Migrate();

            #region Quiz
            if (!context.Quiz.Any(x => x.Name == "Kviz 1"))
            {
                context.Quiz.Add(new Quiz { Name = "Kviz 1" });
            }
            if (!context.Quiz.Any(x => x.Name == "Kviz 2"))
            {
                context.Quiz.Add(new Quiz { Name = "Kviz 2" });
            }
            context.SaveChanges();
            #endregion

            #region QuizQuestion

            if (!context.QuizQuestion.Any(x => x.Question == "Šta se obilježava 25.11?"))
            {
                context.QuizQuestion.Add(new QuizQuestion
                {
                    Question = "Šta se obilježava 25.11?",
                    Answear = "Dan Državnosti BiH",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsDeleted = false,
                });
            }

            if (!context.QuizQuestion.Any(x => x.Question == "Šta se obilježava 1.3?"))
            {
                context.QuizQuestion.Add(new QuizQuestion
                {
                    Question = "Šta se obilježava 1.3?",
                    Answear = "Dan Nezavisnosti BiH",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsDeleted = false,
                });
            }

            context.SaveChanges();
            #endregion

            #region QuizzesQuestions

            var kviz1Id = context.Quiz.First(x => x.Name == "Kviz 1").Id;
            var kviz2Id = context.Quiz.First(x => x.Name == "Kviz 2").Id;

            var q1Id = context.QuizQuestion.First(x => x.Question == "Šta se obilježava 25.11?").Id;
            var q2Id = context.QuizQuestion.First(x => x.Question == "Šta se obilježava 1.3?").Id;

            //TODO:zavrsiti dodavanje podataka
            context.SaveChanges();
            #endregion
        }
    }
}
