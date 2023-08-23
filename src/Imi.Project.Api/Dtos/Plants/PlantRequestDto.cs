using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dtos.Plants
{
    public class PlantRequestDto : BaseDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        public string Condition { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public Guid OwnerId { get; set; }
        public string UserId { get; set; }
    }
}
