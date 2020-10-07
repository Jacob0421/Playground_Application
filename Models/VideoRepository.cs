using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground_Application.Models
{
    public class VideoRepository : IVideoRepository
    {
        List<Video> _videoList;

        public VideoRepository()
        {
            _videoList = new List<Video>()
            {
                new Video {
                    VideoId = 1, 
                    Title = "DIGGING STRAIGHT DOWN... | Minecraft - Part 3",
                    Description = "I've been told that digging straight down is an effective way to get the best resources early on in the game so I'm trying this complicated technique.",
                    Caption = "Markiplier Plays Minecraft - 3rd Video in series",
                    VideoUrl = "https://www.youtube.com/embed/Yk-I7IVLAGo"
                }
        };

        }

        public Video AddVideo(Video videoIn)
        {
            if (_videoList.Any())
                videoIn.VideoId = _videoList.Max(v => v.VideoId) + 1;
            else
                videoIn.VideoId = 1;

            videoIn.VideoUrl = videoIn.VideoUrl.Replace("watch?v=", "embed/");

            _videoList.Add(videoIn);

            return videoIn;
        }

        public Video EditVideoDetails(Video videoChanges)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Video> GetAllVideos()
        {
            return _videoList;
        }

        public Video GetVideo(int id)
        {
            throw new NotImplementedException();
        }

        public Video RemoveVideo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
