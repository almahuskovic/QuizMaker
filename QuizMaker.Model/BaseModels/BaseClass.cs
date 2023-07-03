using System;

namespace QuizMaker.Model.BaseModels
{
    public class BaseClass
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }

        public BaseClass()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
            IsDeleted = false;
        }
    }
}
