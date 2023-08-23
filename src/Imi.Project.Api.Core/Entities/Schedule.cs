using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Schedule: BaseEntity
    {
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public Guid? PlantId { get; set; }
        public Plant Plant { get; set; }
        public Guid? PlantActionId { get; set; }
        public PlantAction PlantAction { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
