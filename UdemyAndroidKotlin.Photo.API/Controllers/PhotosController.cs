using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UdemyAndroidKotlin.Photo.API.Models;

namespace UdemyAndroidKotlin.Photo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", randomFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(stream, cancellationToken);
                }
                var returnPath = "photos/" + randomFileName;

                return Ok(new { Url = returnPath });
            }
            else
            {
                return BadRequest("photo is null");
            }
        }

        [HttpDelete]
        public IActionResult PhotoDelete(PhotoDeleteDto photoDeleteDto)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", photoDeleteDto.Url);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return NoContent();
            }
            return BadRequest();
        }
    }
}