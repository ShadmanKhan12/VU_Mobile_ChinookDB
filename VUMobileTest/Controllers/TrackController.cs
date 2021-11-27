using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUMobileTest.ViewModels;
using VUMobileTest.Models;
using VUMobileTest.Interfaces;

namespace VUMobileTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private ITrackService trackService;

        public TrackController(ITrackService trackService)
        {
            this.trackService = trackService;
        }

        [HttpGet]
        [Route("api/tracks")]
        public IActionResult GetTracks()
        {
            try
            {
                var messages = trackService.GetAllTracks();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("api/tracks/{trackId}")]

        public BooleanResult DeleteSelectedTrack(long trackId)
        {
            bool result = this.trackService.deleteTrack(trackId);
            return new BooleanResult() { Result = result };
        }

        [HttpPut]
        [Route("api/tracks/resouce/{trackId}")]

        public BooleanResult UpdateTrack([FromBody] TrackViewModel track, long trackId)
        {
            bool result = this.trackService.editTrack(track, trackId);
            return new BooleanResult() { Result = result };
        }

        [HttpGet]
        [Route("api/tracks/resouce/{trackName}/{genreName}")]

        public List<TrackViewModel> GetMatchingTracks(string trackName, string genreName)
        {
            var tracks = this.trackService.FindTrackByGenreAndName(trackName, genreName);

            return tracks;
        }
    }
    public class BooleanResult
    {
        public Boolean Result { get; set; }
    }
}
