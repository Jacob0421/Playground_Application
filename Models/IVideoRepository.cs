using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground_Application.Models
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetAllVideos();
        Video GetVideo(int id);
        Video EditVideoDetails(Video videoChanges);
        Video RemoveVideo(int id);
        Video AddVideo(Video videoIn);

    }
}
