using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class ApplicationUserSeeder
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            //admin user
            var admin = new ApplicationUser
            {
                Id = "00000000-0000-0000-0000-000000000001",
                UserName = "ImiAdmin",
                NormalizedUserName = "IMIADMIN",
                Email = "admin@imi.be",
                NormalizedEmail = "ADMIN@IMI.BE",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true
            };
            //hash password
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Test123?");
            //add to applicationuser entity
            modelBuilder.Entity<ApplicationUser>().HasData(admin);

            //add claim to user
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 1,
                    UserId = "00000000-0000-0000-0000-000000000001",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "admin"
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 2,
                    UserId = "00000000-0000-0000-0000-000000000001",
                    ClaimType = "id",
                    ClaimValue = admin.Id
                }) ;

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 3,
                    UserId = "00000000-0000-0000-0000-000000000001",
                    ClaimType = "nickname",
                    ClaimValue = admin.UserName
                }) ;

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 4,
                    UserId = "00000000-0000-0000-0000-000000000001",
                    ClaimType = "email",
                    ClaimValue = admin.Email
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 5,
                    UserId = "00000000-0000-0000-0000-000000000001",
                    ClaimType = "aproved",
                    ClaimValue = admin.HasApprovedTermsAndConditions.ToString()
                });

            //another user
            var user = new ApplicationUser
            {
                Id = "00000000-0000-0000-0000-000000000002",
                UserName = "ImiUser",
                NormalizedUserName = "IMIUSER",
                Email = "user@imi.be",
                NormalizedEmail = "USER@IMI.BE",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                HasApprovedTermsAndConditions = true
            };
            //hash password
            user.PasswordHash = passwordHasher.HashPassword(user, "Test123?");
            //add to table
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            //add claim
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 6,
                    UserId = "00000000-0000-0000-0000-000000000002",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "user"
                });


            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 7,
                    UserId = "00000000-0000-0000-0000-000000000002",
                    ClaimType = "id",
                    ClaimValue = user.Id
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 8,
                    UserId = "00000000-0000-0000-0000-000000000002",
                    ClaimType = "nickname",
                    ClaimValue = user.UserName
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 9,
                    UserId = "00000000-0000-0000-0000-000000000002",
                    ClaimType = "email",
                    ClaimValue = user.Email
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 10,
                    UserId = "00000000-0000-0000-0000-000000000002",
                    ClaimType = "aproved",
                    ClaimValue = user.HasApprovedTermsAndConditions.ToString()
                });

            //another user
            var refuser = new ApplicationUser
            {
                Id = "00000000-0000-0000-0000-000000000003",
                UserName = "ImiRefuser",
                NormalizedUserName = "IMIREFUSER",
                Email = "refuser@imi.be",
                NormalizedEmail = "REFUSER@IMI.BE",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                HasApprovedTermsAndConditions = false
            };
            //hash password
            refuser.PasswordHash = passwordHasher.HashPassword(refuser, "Test123?");
            //add to table
            modelBuilder.Entity<ApplicationUser>().HasData(refuser);

            //add claim
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 11,
                    UserId = "00000000-0000-0000-0000-000000000003",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "user"
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 12,
                    UserId = "00000000-0000-0000-0000-000000000003",
                    ClaimType = "id",
                    ClaimValue = refuser.Id
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 13,
                    UserId = "00000000-0000-0000-0000-000000000003",
                    ClaimType = "nickname",
                    ClaimValue = refuser.UserName
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 14,
                    UserId = "00000000-0000-0000-0000-000000000003",
                    ClaimType = "email",
                    ClaimValue = refuser.Email
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 15,
                    UserId = "00000000-0000-0000-0000-000000000003",
                    ClaimType = "aproved",
                    ClaimValue = refuser.HasApprovedTermsAndConditions.ToString()
                });


            //my user
            var antony = new ApplicationUser
            {
                Id = "00000000-0000-0000-0000-000000000004",
                UserName = "antony.p.moreira@gmail.com",
                NormalizedUserName = "ANTONY.P.MOREIRA@GMAIL.COM",
                Email = "antony.p.moreira@gmail.com",
                NormalizedEmail = "ANTONY.P.MOREIRA@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                HasApprovedTermsAndConditions = true
            };
            //hash password
            antony.PasswordHash = passwordHasher.HashPassword(antony, "Admin123?");
            //add to table
            modelBuilder.Entity<ApplicationUser>().HasData(antony);

            //add claim
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 16,
                    UserId = "00000000-0000-0000-0000-000000000004",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "admin"
                });


            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 17,
                    UserId = "00000000-0000-0000-0000-000000000004",
                    ClaimType = "id",
                    ClaimValue = antony.Id
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 18,
                    UserId = "00000000-0000-0000-0000-000000000004",
                    ClaimType = "nickname",
                    ClaimValue = antony.UserName
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 19,
                    UserId = "00000000-0000-0000-0000-000000000004",
                    ClaimType = "email",
                    ClaimValue = antony.Email
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 20,
                    UserId = "00000000-0000-0000-0000-000000000004",
                    ClaimType = "aproved",
                    ClaimValue = antony.HasApprovedTermsAndConditions.ToString()
                });


            //friend as admin
            var terence = new ApplicationUser
            {
                Id = "00000000-0000-0000-0000-000000000005",
                UserName = "terence.joiris@protonmail.com",
                NormalizedUserName = "TERENCE.JOIRIS@PROTONMAIL.COM",
                Email = "terence.joiris@protonmail.com",
                NormalizedEmail = "TERENCE.JOIRIS@PROTONMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                HasApprovedTermsAndConditions = true
            };
            //hash password
            terence.PasswordHash = passwordHasher.HashPassword(terence, "Admin123?");
            //add to table
            modelBuilder.Entity<ApplicationUser>().HasData(terence);

            //add claim
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 21,
                    UserId = "00000000-0000-0000-0000-000000000005",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "admin"
                });


            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 22,
                    UserId = "00000000-0000-0000-0000-000000000005",
                    ClaimType = "id",
                    ClaimValue = terence.Id
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 23,
                    UserId = "00000000-0000-0000-0000-000000000005",
                    ClaimType = "nickname",
                    ClaimValue = terence.UserName
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 24,
                    UserId = "00000000-0000-0000-0000-000000000005",
                    ClaimType = "email",
                    ClaimValue = terence.Email
                });

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 25,
                    UserId = "00000000-0000-0000-0000-000000000005",
                    ClaimType = "aproved",
                    ClaimValue = terence.HasApprovedTermsAndConditions.ToString()
                });
        }

    }
}
