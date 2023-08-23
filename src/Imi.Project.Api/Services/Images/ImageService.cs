namespace Imi.Project.Api.Services.Images
{
    public class ImageService : IImageService
    {
        private readonly IHostEnvironment _webHostEnvironment;

        public ImageService(IHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> AddOrUpdateImageAsync<T>(Guid entityId, IFormFile image)
        {
            // stelt het pad in voor de afbeelding in de database
            var pathForDatabase = Path.Combine("images",
                typeof(T).Name.ToLower()); // Leest de naam van het T-type als string

            // haalt het pad op naar de map waar we afbeeldingen willen opslaan
            var folderPathForImages = Path.Combine(
                _webHostEnvironment.ContentRootPath, //Haalt de rooturl op van het bestandssysteem op de server van de root naar de map van het API-project
                "wwwroot",
                pathForDatabase);


            // maakt folder als er geen is
            if (!Directory.Exists(folderPathForImages))
            {
                Directory.CreateDirectory(folderPathForImages);
            }

            // haal de extensie uit een bestand (dit omvat de . (punt)), bijvoorbeeld: .jpg
            var fileExtension = Path.GetExtension(image.FileName);

            // maak een nieuwe bestandsnaam voor de afbeelding, in dit geval is de bestandsnaam de entityId, bijvoorbeeld: 56eb6039-1959-4413-82c5-08d98db42562.jpg
            var newFileNameWithExtension = $"{entityId}{fileExtension}";

            // krijgt het volledige bestandspad
            var filePath = Path.Combine(folderPathForImages, newFileNameWithExtension);

            // opslaan van de afbeelding
            if (image.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
            }

            var filePathForDatabase = Path.Combine(pathForDatabase, newFileNameWithExtension);

            return filePathForDatabase;
        }
    }
}
