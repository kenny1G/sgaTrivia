using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bc_awareness.Models
{
    // a view model class that enables me to pass the question and a list of answer options to the view.
    public class QuestionViewModel
    {
        public Trivia Question { get; set; }
        public List<string> AnswerOptions { get; set; }

        public QuestionViewModel(Trivia question)
        {
            this.Question = question;
            AnswerOptions = new List<string>();
            this.AnswerOptions.Add(Question.Answer);
            this.AnswerOptions.Add("Dummy 1");
            this.AnswerOptions.Add("Dummy 2");
            this.AnswerOptions.Add("Dummy 3");
        }

    }
}
