using System;
using System.Collections.Generic;
using System.Text;
using Entities.Configurations;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());

        }
    }
}
