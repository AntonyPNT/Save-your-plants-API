using Imi.Project.Api.Dtos.Accounts;

namespace Imi.Project.Api.Dtos.Plants
{
    public class PlantResponseDto : BaseDto
    {
        public string Name { get; set; }
        public string Condition { get; set; }
        public string Image { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public AccountsResponseDto User { get; set; }
    }
}
