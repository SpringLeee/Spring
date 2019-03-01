using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CoreWebAPI
{
    public partial class LocalDBContext : DbContext
    { 
        public LocalDBContext(DbContextOptions<LocalDBContext> options, IConfiguration configuration)
            : base(options)
        { 
            
        }

        public virtual DbSet<Students> Students { get; set; } 
        
     
    }
}
