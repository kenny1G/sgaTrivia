using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace bc_awareness.Models
{
    public class Trivia
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Source { get; set; }
        public string Fact { get; set; }
        //public ICollection<Answer> Answers { get; set; }
        //public ICollection<Answer> CorrectAnswer { get; set; }

        public override String ToString() => JsonSerializer.Serialize<Trivia>(this);
        
    }

    public class Answer
    {
        public int Id { get; set; }
        public string DisplayString { get; set; }
    }
}
