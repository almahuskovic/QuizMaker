using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Model.BaseModels
{
    public class BaseClass
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
