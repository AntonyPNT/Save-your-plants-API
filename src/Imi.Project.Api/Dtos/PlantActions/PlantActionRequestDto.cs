using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Dtos.PlantActions
{
    public class PlantActionRequestDto : BaseDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
    }
}
