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

            if (!context.QuizQuestion.Any(x => x.Question == "Koji je glavni grad Japana?"))
            {
                context.QuizQuestion.Add(new QuizQuestion
                {
                    Question = "Koji je glavni grad Japana?",
                    Answer = "Tokyo",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsDeleted = false,
                });
            }

            if (!context.QuizQuestion.Any(x => x.Question == "Koji je najveci planinski vrh u BiH?"))
            {
                context.QuizQuestion.Add(new QuizQuestion
                {
                    Question = "Koji je najveci planinski vrh u BiH?",
                    Answer = "Maglic(2386m)",
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

            var q1Id = context.QuizQuestion.First(x => x.Question == "Koji je glavni grad Japana?").Id;
            var q2Id = context.QuizQuestion.First(x => x.Question == "Koji je najveci planinski vrh u BiH?").Id;

            context.QuizzesQuestions.Add(new QuizzesQuestions
            {
                QuizId= kviz1Id,
                QuizQuestionId= q1Id,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsDeleted = false,
            });

            context.QuizzesQuestions.Add(new QuizzesQuestions
            {
                QuizId = kviz1Id,
                QuizQuestionId = q2Id,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsDeleted = false,
            });

            context.QuizzesQuestions.Add(new QuizzesQuestions
            {
                QuizId = kviz2Id,
                QuizQuestionId = q2Id,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsDeleted = false,
            });

            context.SaveChanges();
            #endregion
        }
    }
}
