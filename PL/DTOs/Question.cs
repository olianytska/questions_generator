using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DTOs
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
