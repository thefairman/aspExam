using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    public partial class AppDbContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(gr => gr.Students)
                .HasForeignKey(s => s.GroupId);

            builder.Entity<Group>()
               .HasOne(s => s.Faculty)
               .WithMany(gr => gr.Groups)
               .HasForeignKey(s => s.FacultyId);


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrators",
                    NormalizedName = "ADMINISTRATORS",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Moderators",
                    NormalizedName = "MODERATORS",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "859f28ed-0bc8-4413-a1d9-c4e71f89e49f",
                    UserId = "d5a63167-9ad9-4f05-bff3-74dc627818da"
                });

            builder.Entity<Faculty>().HasData(
                new Faculty { Id = Guid.NewGuid(), Name = "Системного администрирования" },
                new Faculty { Id = Guid.NewGuid(), Name = "Программирования" },
                new Faculty { Id = Guid.NewGuid(), Name = "Компьютерной графики т дизайна" },
                new Faculty { Id = Guid.NewGuid(), Name = "Годичные курсы" },
                new Faculty { Id = Guid.NewGuid(), Name = "Базовый курс" });

            base.OnModelCreating(builder);
        }
    }
}
