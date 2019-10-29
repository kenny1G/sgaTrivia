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
        public string AnswerOption1 { get; set; }
        public string AnswerOption2 { get; set; }
        public string AnswerOption3 { get; set; }
        public string Source { get; set; }
        public string Fact { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Trivia>(this);
    }
}
