using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DotNetCoreCalendar.Controllers.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpaProjectFinalProject.Data;
using SpaProjectFinalProject.Models;
using SpaProjectFinalProject.Models.ViewModels;
using SpaProjectFinalProject.Services;

namespace SpaProjectFinalProject.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IDAl _dal;
        private readonly UserManager<ApplicationUser> _usermanager;

        public EventController(IDAl dal, UserManager<ApplicationUser> usermanager)
        {
            _dal = dal;
            _usermanager = usermanager;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(await _dal.GetMyEvents(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        #region Details from Event
        // GET: Event/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }
        #endregion

        #region Create an Event
        // GET: Event/Create

        public async Task<IActionResult> Create()
        {
            return View(new EventViewModel(await _dal.GetAnimals(), User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(EventViewModel vm, IFormCollection form)
        {
            try
            {
                  await _dal.CreateEvent(form);
                TempData["Alert"] = "Success! You created a new event for: " + form["Event.Name"];
                return RedirectToAction("MyCalendar", "Calendar");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                return View(vm);
            }
        }

        #endregion
        [UserAccessOnly]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            var vm = new EventViewModel(@event, await _dal.GetAnimals(), User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(vm);
        }
     
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {
            try
            {
                await _dal.UpdateEvent(form);
                TempData["Alert"] = "Success! You modified an event for: " + form["Event.Name"];
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new EventViewModel(await _dal.GetEvent(id),await _dal.GetAnimals(), User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View(vm);
            }
        }
 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = await _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _dal.DeleteEvent(id);
            TempData["Alert"] = "You deleted an event.";
            return RedirectToAction(nameof(Index));
        }
    }
}
