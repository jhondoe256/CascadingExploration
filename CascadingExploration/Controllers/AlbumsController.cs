using CascadeExploration.Models.AlbumModels;
using CascadeExploration.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CascadingExploration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var albums = await _albumService.GetAlbums();
            return Ok(albums);
        }

        [HttpGet,Route("{id:int}")]
        public async Task<IActionResult>Get(int id)
        {
            var album = await _albumService.GetAlbum(id);
            if (album is null) return NotFound();

            return Ok(album);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlbumCreate model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if (await _albumService.AddAlbum(model)) return Ok();

            return StatusCode(500, "Internal Server Error");
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlbumEdit model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _albumService.EditAlbum(model)) return Ok();

            return StatusCode(500, "Internal Server Error");
        }

        [HttpDelete,Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _albumService.DeleteAlbum(id)) return Ok();

            return StatusCode(500, "Internal Server Error");
        }

    }
}
