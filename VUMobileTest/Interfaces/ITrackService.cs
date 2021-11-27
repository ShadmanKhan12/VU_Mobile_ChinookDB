using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUMobileTest.Models;
using VUMobileTest.ViewModels;

namespace VUMobileTest.Interfaces
{
    public interface ITrackService
    {
        List<TrackViewModel> GetAllTracks();

        bool deleteTrack(long trackId);

        bool editTrack(TrackViewModel track, long trackId);

        List<TrackViewModel> FindTrackByGenreAndName(string track, string genreName);

    }
}
