using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace bc_awareness.Models
{
    public class Trivia
    {
        //attributes from the json.
        public string Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Source { get; set; }
        public string Fact { get; set; }


        //public List<String> AnswerOptions { get; set; }


        public Trivia()
        {
        }
        //public ICollection<Answer> CorrectAnswer { get; set; }


        //incase we ever need to get the questions in json format.
        public override String ToString() => JsonSerializer.Serialize<Trivia>(this);
        
    }

    public class Answer
    {
        public int Id { get; set; }
        public string DisplayString { get; set; }
    }
}
