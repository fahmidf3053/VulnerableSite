using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VulnerableWebApp.Interfaces;
using VulnerableWebApp.Models;

namespace VulnerableWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataAccessService _dataAccessService;

        public HomeController(ILogger<HomeController> logger, IDataAccessService dataAccessService)
        {
            _logger = logger;
            _dataAccessService = dataAccessService;
        }

        public IActionResult Index()
        {
            string userName = HttpContext.Session.GetString("CurrentUser");

            if (!string.IsNullOrWhiteSpace(userName))
            {
                return RedirectToAction("Profile");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginModel)
        {
            try
            {
                User user = _dataAccessService.GetAllUsers().
                    Where(x => x.UserName == loginModel.UserName).FirstOrDefault();

                if (user == null)
                    throw new Exception();

                if(user.Password != loginModel.Password)
                    throw new Exception();

                HttpContext.Session.SetString("CurrentUser", loginModel.UserName); 
                
                return RedirectToAction("Profile");
                
            }
            catch (Exception ex)
            {             
                ViewBag.message = $"Sorry, your UserName: {loginModel.UserName} or Password didn't match";            
            }

            return View();
        }

        public IActionResult Profile()
        {
            string userName = HttpContext.Session.GetString("CurrentUser");

            ProfileViewModel profileViewModel = new();
            profileViewModel.Name = userName;
            List<Request> myRequest = _dataAccessService.GetAllRequests().
                Where(x => x.RequestTo == userName).ToList();

            List<User> toBeSent = _dataAccessService.GetAllUsers().
                Where( x => x.UserName != userName).ToList();

            profileViewModel.RequestToBeSent= toBeSent;
            profileViewModel.IncomingRequest = myRequest;

           return View(profileViewModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("CurrentUser");

            return RedirectToAction("Index");
        }

        public IActionResult AddFriend(string to)
        {
            string userName = HttpContext.Session.GetString("CurrentUser");

            Request request= new Request();

            request.RequestFrom = userName;
            request.RequestTo = to;
            request.CreatedTime = DateTime.Now;
            request.EntityState = Constants.EntityState.Added;

            _dataAccessService.AddRequests(request);

            return RedirectToAction("Profile");
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
