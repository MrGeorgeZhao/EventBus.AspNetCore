using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eventbus.AspNetCore.Abstractions;
using WebApplication1.Handlers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IEventBus _eventBus;

        public HomeController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public IActionResult Index()
        {
            UserUpdateEvent userUpdateEvent = new UserUpdateEvent() { Id = Guid.NewGuid(), Name = "zhangsan " };

            _eventBus.Publish(userUpdateEvent);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
