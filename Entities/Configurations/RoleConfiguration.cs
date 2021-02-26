using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        //Add-Migration AddRolesToDb -Context UserContext
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Name = "Visitor",
                NormalizedName = "VISITOR",
                Id = Guid.NewGuid().ToString()
            });
        }
    }
}
