using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bc_awareness.Models
{
    public class Trivia
    {
        public int Id { get; set; }
        public string QuestionString { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Answer> CorrectAnswer { get; set; }
    }

    public class Answer
    {
        public int Id { get; set; }
        public string DisplayString { get; set; }
    }
}
