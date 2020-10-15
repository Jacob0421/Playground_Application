using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Playground_Application.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Playground_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVideoRepository _videoList;
        private readonly IUserRepository _UserList;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IVideoRepository videoRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _videoList = videoRepository;
            _UserList = userRepository;
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

        public IActionResult HashedPasswords()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HashedPasswords(string plainText)
        {
            byte[] salt = new byte[256 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            ViewBag.Salt = "Salt: " + Convert.ToBase64String(salt);
            ViewBag.PasswordHash = "Password Hash: " + Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plainText,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)) ;

            return View();
        }
        
        public IActionResult AddUserAndLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login (string passwordIn, string usernameIn)
        {
            User userIn = _UserList.GetUserbyUsername(usernameIn);

            var storedSalt = Convert.FromBase64String(userIn.Salt);

            var questionableHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: passwordIn,
                salt: storedSalt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                ));

            var storedHash = userIn.PasswordHash;

            if (questionableHash == storedHash)
                ViewBag.Result = "Yay!";
            else
                ViewBag.Result = "Something Went Wrong...";

            return View("AddUserAndLogin");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
