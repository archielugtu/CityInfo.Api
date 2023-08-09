using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.Api.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? 
                throw new ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            // Build-in classes that can help you with working with files
            // 1. FileContentResult - accepts file bytes and content type for the file
            // 2. FileStream - accepts a stream to read from and content type
            // 3. PhysicalFileResult - allows you to pass through a filename and a content type
            // 4. VirtualFileResult - allows you to pass through a filename and a content type

            // These 4 different classes all derive from FileResult class


            // Instead of using those built-in helper classes, you can use the File() method defined in the ControllerBase class and acts as a wrapper to the aforementioned classes
            // return File()''

            var pathToFile = "july.pdf";

            if (!System.IO.File.Exists(pathToFile))
                return NotFound();

            // retrieve content type, if unable then set it to octet-stream
            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
                contentType = "application/octet-stream"; // default media type for arbitrary binary data.

            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
