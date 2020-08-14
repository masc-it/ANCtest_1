using JobTracker.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracker.Data
{
    public class JobDbContext : DbContext
    {
        public JobDbContext() { }
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=onipot_test;Username=postgres;Password=toor");

        public DbSet<Job> Job { get; set; }
    }
}
