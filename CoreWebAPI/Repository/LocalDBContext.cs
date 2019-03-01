using System;
using CoreWebAPI.Models;
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

        public virtual DbSet<Student> Students { get; set; } 
        
     
    }
}
