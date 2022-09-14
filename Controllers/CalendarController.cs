using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaProjectFinalProject.Models;
using SpaProjectFinalProject.Services;
using System.Security.Claims;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using SpaProjectFinalProject.Helpers;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace SpaProjectFinalProject.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly IDAl _idal;
        private readonly UserManager<ApplicationUser> _usermanager;

        public CalendarController(ILogger<CalendarController> logger, IDAl idal, UserManager<ApplicationUser> usermanager)
        {
            _logger = logger;
            _idal = idal;
            _usermanager = usermanager;
        }

        #region See Calendar
        //public IActionResult Index()
        //{
        //    ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_idal.GetAnimals());
        //    ViewData["Events"] = JSONListHelper.GetEventListJSONString(_idal.GetEvents());
        //    return View();
        //} 
        #endregion

        [Authorize]
        #region See All calendar With connected User
        public async Task<IActionResult> MyCalendarAsync()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(await _idal.GetAnimals());
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(await _idal.GetMyEvents(userid));
            return View();
        } 
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region PageNotFound
        public ViewResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View();
        } 
        #endregion
    }
}
