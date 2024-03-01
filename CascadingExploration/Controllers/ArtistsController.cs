using CascadeExploration.Models.ArtistModels;
using CascadeExploration.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CascadingExploration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _artistService.GetArtists());
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var artist = await _artistService.GetArtist(id);
            if (artist is null) return NotFound();
            return Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ArtistCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _artistService.AddArtist(model))
                return Ok();
            else
                return StatusCode(500, "Internal Server Error.");

        }

        [HttpPut]
        public async Task<IActionResult> Put(ArtistEdit model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _artistService.EditArtist(model))
                return Ok();
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpDelete,Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _artistService.DeleteArtist(id))
                return Ok();
            else
                return StatusCode(500, "Internal Server Error.");
        }

    }
}
