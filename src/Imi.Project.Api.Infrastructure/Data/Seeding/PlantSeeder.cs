using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class PlantSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>().HasData(                                                                                 
                new Plant { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Anthurium", Condition = "Healthy", DateOfPurchase = DateTime.Now, ApplicationUserId = "00000000-0000-0000-0000-000000000001", Image = "images/plant/Anthurium.jpg" },
                new Plant { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Lucky-Bamboo", Condition = "Healthy", DateOfPurchase = DateTime.Now, ApplicationUserId = "00000000-0000-0000-0000-000000000001", Image = "images/plant/Bamboo.jpg" },
                new Plant { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Croton", Condition = "Healthy", DateOfPurchase = DateTime.Now, ApplicationUserId = "00000000-0000-0000-0000-000000000001", Image = "images/plant/Croton.jpg" },
                new Plant { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Dracaena", Condition = "Unhealthy", DateOfPurchase = DateTime.Now, ApplicationUserId = "00000000-0000-0000-0000-000000000002", Image = "images/plant/Dracaena.jpg" },
                new Plant { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Dracaena-Marginata", Condition = "Healthy", DateOfPurchase = DateTime.Now, ApplicationUserId = "00000000-0000-0000-0000-000000000002", Image = "images/plant/Dracaena-Marginata.jpg" },
                new Plant { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Orchid", Condition = "Unhealthy", DateOfPurchase = DateTime.Now, ApplicationUserId = "00000000-0000-0000-0000-000000000002", Image = "images/plant/Orchid.jpg" },
                new Plant { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Peace-Lily", Condition = "Unhealthy", DateOfPurchase = DateTime.Now, ApplicationUserId = "00000000-0000-0000-0000-000000000003", Image = "images/plant/Peace-Lily.jpg" },
                new Plant { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Ponytail", Condition = "Healthy", DateOfPurchase = DateTime.Now, ApplicationUserId = "00000000-0000-0000-0000-000000000003", Image = "images/plant/Ponytail.jpg" },
                new Plant { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Pothos", Condition = "Healthy", DateOfPurchase = DateTime.Now, ApplicationUserId = "00000000-0000-0000-0000-000000000004", Image = "images/plant/Pothos.jpg" },
                new Plant { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Snake-Plant", Condition = "Healthy", DateOfPurchase = DateTime.Now, ApplicationUserId = "00000000-0000-0000-0000-000000000004", Image = "images/plant/Snake-Plant.jpg" }
                );
        }
    }
}
