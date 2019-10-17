using Microsoft.EntityFrameworkCore;
using bc_awareness.Models;

namespace bc_awareness.Data
{
    public class TriviaContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TriviaContext (DbContextOptions<TriviaContext> options) : base (options)
        {

        }

        public DbSet<Trivia> Trivia { get; set; }
    }
}
