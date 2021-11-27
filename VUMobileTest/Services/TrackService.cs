using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUMobileTest.Interfaces;
using VUMobileTest.Models;
using VUMobileTest.ViewModels;

namespace VUMobileTest.Services
{
    public class TrackService : ITrackService
    {
        private chinookContext db;

        public TrackService(chinookContext db)
        {
            this.db = db;
        }

        public List<TrackViewModel> GetAllTracks()
        {
            if (db != null)
            {
                List<TrackViewModel> tracks = new List<TrackViewModel>();

                var result = from o in db.Tracks
                             orderby o.Album ascending, o.Composer ascending
                             select o;
                foreach (var r in result)
                {
                    TrackViewModel track = new TrackViewModel();
                    track.Name = r.Name;
                    track.TrackId = r.TrackId;
                    track.Composer = r.Composer;
                    tracks.Add(track);
                }

                return tracks;
            }

            return null;
        }
        public List<TrackViewModel> FindTrackByGenreAndName(string trackName, string genreName)
        {
            if(db != null)
            {
                List<TrackViewModel> tracks = new List<TrackViewModel>();
                var foundTracks = db.Tracks.Where(c => c.Name == trackName || c.Genre.Name == genreName);

                foreach (var newtrack in foundTracks)
                {
                    TrackViewModel track = new TrackViewModel();
                    track.Name = newtrack.Name;
                    track.TrackId = newtrack.TrackId;
                    track.Composer = newtrack.Composer;
                    tracks.Add(track);
                }
                return tracks;
            }
            return null;
        }

        public bool editTrack(TrackViewModel track, long trackId)
        {
            if(db != null)
            {
                var itemToUpdate = db.Tracks.SingleOrDefault(x => x.TrackId == trackId);

                if(itemToUpdate != null)
                {
                    itemToUpdate.Name = track.Name;
                    itemToUpdate.Composer = track.Composer;
                    db.Update(itemToUpdate);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool deleteTrack(long trackId)
        {
            if (db != null)
            {
                var itemToRemove = db.Tracks.SingleOrDefault(x => x.TrackId == trackId); //returns a single item.

                if (itemToRemove != null)
                {
                    db.Tracks.Remove(itemToRemove);
                    //db.Entry(itemToRemove).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                return true;
            }
            return false;

        }
    }
}
