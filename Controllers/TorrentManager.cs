using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorrentManager.Database;
using TorrentManager.Database.Models;

namespace TorrentManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorrentManagerController : ControllerBase
    {
        #region fields with contructors
        public readonly DatabaseContext _dbcontext;
        public TorrentManagerController(DatabaseContext context) 
        {
            _dbcontext = context;
        }
        #endregion

        /// <summary>
        /// Returns all media requests for the current day
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/[controller]/list")]
        public async Task<IActionResult> List()
        {
            List<MediaRequestModel> mediaRequests = await _dbcontext.MediaRequests.Where(mediaRequest => mediaRequest.CreatedDate == DateTime.Now).ToListAsync();

            return Ok(mediaRequests);
        }

        /// <summary>
        /// Add new media request
        /// </summary>
        /// <param name="mediaRequestModel"></param>
        /// <returns></returns>
        [HttpPost("api/[controller]/create")]
        public async Task<IActionResult> Create(MediaRequestModel mediaRequestModel)
        {
            try
            {
                _dbcontext.MediaRequests.Add(mediaRequestModel);
                await _dbcontext.SaveChangesAsync();

                return Ok("Media request successfully added.");
            }
            catch (Exception exp)
            {
                return BadRequest($"Failed to add media request.\n {exp.Message}");
            }
        }

        /// <summary>
        /// Upload and saves a .torrent file on the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("api/[controller]/UploadTorrentFile")]
        public IActionResult UploadTorrentFile(IFormFile file)
        {
            if (!Path.GetExtension(file.FileName).ToLower().Equals(".torrent"))
                return BadRequest("Please provide a .torrent file");

            Directory.CreateDirectory($"./torrents");

            using (FileStream fs = System.IO.File.OpenWrite($"./torrents/{file.FileName}"))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                file.CopyToAsync(fs);
                sw.Write(fs);
            }

            return Ok("Succesfully uploaded.");
        }
    }
}
