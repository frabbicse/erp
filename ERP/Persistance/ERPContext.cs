using Microsoft.EntityFrameworkCore;

using Models;
using Models.Auth;

using System;

namespace Persistance
{
    public class ERPContext : DbContext
    {
      public ERPContext(DbContextOptions options) : base(options)
        { }

        // authentication , authorization
        public DbSet<Register> Register{ get; set; }
        public DbSet<Login> Login{ get; set; }

        public DbSet<Role> Roles{ get; set; }
    }
}
