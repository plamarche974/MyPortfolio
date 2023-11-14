using Microsoft.EntityFrameworkCore;

namespace MediaData
{
    using System.Runtime.Serialization;
    public class DataDBContext : DbContext
    {

        public DataDBContext(DbContextOptions<DataDBContext> options): base(options)
        {

        }

        public DbSet<Work> Works { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Participation> Participations { get; set; }
    }
}
