using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCity.Models
{
    public class BlogDataContext:DbContext
    {
        
        public BlogDataContext(DbContextOptions<BlogDataContext> options):base (options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Post> Posts { get; set; }
    }
}
