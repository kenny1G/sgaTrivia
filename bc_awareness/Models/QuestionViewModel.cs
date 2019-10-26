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
        public int nextIndex { get; set; }

        public QuestionViewModel()
        {
            this.Question = new Trivia();
            this.nextIndex = 1;
        }

    }
}
