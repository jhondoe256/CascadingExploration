using CascadeExploration.Models.TrackModels;
using CascadeExploration.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CascadingExploration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _trackService.GetTracks());
        }

        [HttpGet,Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _trackService.GetTrack(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(TrackCreate model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            return await _trackService.AddTrack(model) ? Ok() : StatusCode(500, "Internal Server Error");
        }

        [HttpPut, Route("{id:int}")]
        public async Task<IActionResult> Put(TrackEdit model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return await _trackService.EditTrack(model) ? Ok() : StatusCode(500, "Internal Server Error");
        }

        [HttpDelete, Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return await _trackService.DeleteTrack(id) ? Ok() : StatusCode(500, "Internal Server Error");
        }
    }
}
