namespace Ecommerce.WebApi.Helpers
{
    public static class ImageHelper
    {
        public static string SaveFile(IFormFile photoUrl)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + photoUrl.FileName;
            string tempPath = "TemporaryUploadedFiles/" + uniqueFileName;
            using (FileStream stream = new FileStream(tempPath, FileMode.CreateNew))
            {
                photoUrl.CopyTo(stream);
            }

            return tempPath;
        }
    }
}
