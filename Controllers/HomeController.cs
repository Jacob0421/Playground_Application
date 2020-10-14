using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Playground_Application.Models;

namespace Playground_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVideoRepository _videoList;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IVideoRepository videoRepository)
        {
            _logger = logger;
            _videoList = videoRepository;
        }

        public IActionResult Index()
        {
            return View(_videoList.GetAllVideos());
        }

        public IActionResult AddVideo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVideo(Video videoIn)
        {
            _videoList.AddVideo(videoIn);
            return RedirectToAction("Index");
        }

        public IActionResult ShowDivsOnSelect()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
