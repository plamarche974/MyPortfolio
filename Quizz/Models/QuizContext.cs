using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Quizz.Models
{
    public class QuizContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Score> Scores { get; set; }

        public QuizContext(DbContextOptions<QuizContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Vous pouvez ajouter ici des configurations supplémentaires si nécessaire
        }

    }

}
