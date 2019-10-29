using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace bc_awareness.Models
{
    public class Leaderboard
    {
        public string id { get; set; }
        public string user { get; set; }
        public string studentId { get; set; }
        public string score { get; set; }
        public string email { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Leaderboard>(this);
    }
}
