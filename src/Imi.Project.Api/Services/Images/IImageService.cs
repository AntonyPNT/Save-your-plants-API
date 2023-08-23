namespace Imi.Project.Api.Services.Images
{
    public interface IImageService
    {
        Task<string> AddOrUpdateImageAsync<T>(Guid entityId, IFormFile image);
    }
}
