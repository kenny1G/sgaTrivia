using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bc_awareness.Models
{
    // a view model class that enables me to pass the question and the index of the next question to the view method.
    public class QuestionViewModel
    {
        public Trivia Question { get; set; }
        public int NextIndex { get; set; }
        public List<string> AnswerOptions { get; set; }

        public QuestionViewModel(Trivia question, int nextIndex)
        {
            this.Question = question;
            this.NextIndex = nextIndex;
            AnswerOptions = new List<string>();
            this.AnswerOptions.Add(Question.Answer);
            this.AnswerOptions.Add("Dummy 1");
            this.AnswerOptions.Add("Dummy 2");
            this.AnswerOptions.Add("Dummy 3");
        }

    }
}
