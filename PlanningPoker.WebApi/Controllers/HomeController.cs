using Microsoft.AspNetCore.Mvc;
using PlanningPoker.WebApi.Services;

namespace PlanningPoker.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private SessionHolder _sessionHolder;

        public HomeController(SessionHolder sessionHolder)
        {
            _sessionHolder = sessionHolder;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Session")]
        public IActionResult Session(string id, string userName)
        {
            var session = _sessionHolder.GetSession(id);
            return View(session);
        }

        [HttpGet]
        [Route("toggle-hidden")]
        public IActionResult ToggleHidden(string id)
        {
            var session = _sessionHolder.GetSession(id);
            if (session != null)
            {
                session.IsHidden = !session.IsHidden;
            }

            return RedirectToAction("Session", "Home", new {id = id});
        }

        [HttpGet]
        public IActionResult Create()
        {
            var session = _sessionHolder.CreateSession();
            return View("Session", session);
        }
    }
}