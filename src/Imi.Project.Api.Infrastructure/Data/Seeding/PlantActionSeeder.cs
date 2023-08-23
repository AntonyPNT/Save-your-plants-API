using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class PlantActionSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantAction>().HasData(
                new PlantAction { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "water"},
                new PlantAction { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "fertilize"},
                new PlantAction { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "repot" }
                );
        }
    }
}
