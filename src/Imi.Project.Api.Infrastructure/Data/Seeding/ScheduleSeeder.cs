using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class ScheduleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Date = DateTime.Now, PlantActionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), PlantId = Guid.Parse("00000000-0000-0000-0000-000000000001"), ApplicationUserId = "00000000-0000-0000-0000-000000000001", IsCompleted = false },
                new Schedule { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Date = DateTime.Now, PlantActionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), PlantId = Guid.Parse("00000000-0000-0000-0000-000000000002"), ApplicationUserId = "00000000-0000-0000-0000-000000000001", IsCompleted = false },
                new Schedule { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Date = DateTime.Now, PlantActionId = Guid.Parse("00000000-0000-0000-0000-000000000003"), PlantId = Guid.Parse("00000000-0000-0000-0000-000000000003"), ApplicationUserId = "00000000-0000-0000-0000-000000000001", IsCompleted = false },
                new Schedule { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Date = DateTime.Now, PlantActionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), PlantId = Guid.Parse("00000000-0000-0000-0000-000000000004"), ApplicationUserId = "00000000-0000-0000-0000-000000000002", IsCompleted = false },
                new Schedule { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Date = DateTime.Now, PlantActionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), PlantId = Guid.Parse("00000000-0000-0000-0000-000000000005"), ApplicationUserId = "00000000-0000-0000-0000-000000000002", IsCompleted = false },
                new Schedule { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Date = DateTime.Now, PlantActionId = Guid.Parse("00000000-0000-0000-0000-000000000003"), PlantId = Guid.Parse("00000000-0000-0000-0000-000000000006"), ApplicationUserId = "00000000-0000-0000-0000-000000000002", IsCompleted = false },
                new Schedule { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Date = DateTime.Now, PlantActionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), PlantId = Guid.Parse("00000000-0000-0000-0000-000000000007"), ApplicationUserId = "00000000-0000-0000-0000-000000000003", IsCompleted = false },
                new Schedule { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Date = DateTime.Now, PlantActionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), PlantId = Guid.Parse("00000000-0000-0000-0000-000000000008"), ApplicationUserId = "00000000-0000-0000-0000-000000000003", IsCompleted = false },
                new Schedule { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Date = DateTime.Now, PlantActionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), PlantId = Guid.Parse("00000000-0000-0000-0000-000000000009"), ApplicationUserId = "00000000-0000-0000-0000-000000000004", IsCompleted = false },
                new Schedule { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Date = DateTime.Now, PlantActionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), PlantId = Guid.Parse("00000000-0000-0000-0000-000000000010"), ApplicationUserId = "00000000-0000-0000-0000-000000000004", IsCompleted = false }
                );
        }
    }
}
