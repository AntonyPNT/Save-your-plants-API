using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Plant: BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string Condition { get; set; }
        public string Image { get; set; }
        //public Guid? OwnerId { get; set; }
        //public Owner Owner { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
