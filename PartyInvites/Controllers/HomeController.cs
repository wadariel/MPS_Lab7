using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System;
using System.Security.Cryptography.X509Certificates;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Greeting"] = GetGreeting();
            return View();
        }

        private string GetGreeting()
        {
            var currentTime = DateTime.Now;
            string greeting;

            if (currentTime.Hour >= 6 && currentTime.Hour < 11)
            {
                greeting = "Доброе утро";
            }
            else if (currentTime.Hour >= 11 && currentTime.Hour < 17)
            {
                greeting = "Добрый день";
            }
            else if (currentTime.Hour >= 17 && currentTime.Hour < 22)
            {
                greeting = "Добрый вечер";
            }
            else
            {
                greeting = "Доброй ночи";
            }
            return greeting; 
        }

        [HttpGet]
        public ViewResult AcceptForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AcceptForm(GuestResponse guestResponse) 
        {
            if (ModelState.IsValid) 
            {
                
                return View("Thanks", guestResponse); 
            }
            else
            {
                return View();
            }
        }
    }
}
