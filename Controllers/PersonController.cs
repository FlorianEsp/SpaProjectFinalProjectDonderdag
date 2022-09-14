using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpaProjectFinalProject.GenericRepo;
using SpaProjectFinalProject.Models;
using SpaProjectFinalProject.Paging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Pager = SpaProjectFinalProject.Models.Pager;

namespace SpaProjectFinalProject.Controllers
{
    public class PersonController : Controller
    {
        private readonly IRepo _repo;
        public PersonController(IRepo repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchstring, int pg = 1)
        {
            //*******************************************personen tonen
            var model = await _repo.SelectAsync<Person>();
            //ViewBag.AnimalsDbPerson = new SelectList(await _repo.SelectAsync<Animal>(), "AnimalId", "Name");/*Waarom werkt deze */
            ////Sorteren
            ViewBag.NameSort = string.IsNullOrEmpty(sortOrder) ? "name_sort" : "";
            ViewBag.AddressSort = sortOrder == "Address" ? "address_sort" : "Address";
            switch (sortOrder)
            {
                case "name_sort":
                    model = model.OrderByDescending(b => b.Name).ToList();
                    break;
               
                case "Address":
                    model = model.OrderBy(x => x.Address).ToList();
                    break;
                case "address_sort":
                    model = model.OrderByDescending(x => x.Address).ToList();
                    break;
                default:
                    model = model.OrderBy(b => b.Name).ToList();
                    break;

            }
            //**************************************************Zoek optie
            if (!string.IsNullOrEmpty(searchstring))
            {
                model = model.Where(x => x.Name.Contains(searchstring, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            //******************************************************paging
            const int pageSize = 5;
            if (pg < 1)//gebruikt in geval dat user kleiner wilt gaan dan 1 blijft hij op een.
            {
                pg = 1;
            }
            int recsCount = model.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = model.Skip(recSkip).Take(pageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Persons = new SelectList(await _repo.SelectAsync<Animal>(), "AnimalId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            await _repo.Create<Person>(person);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var person = await _repo.SelectById<Person>(id);
            return View(person);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            await _repo.UpdateAsync<Person>(person);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeletePerson(int PersonId)
        {
            var person = await _repo.SelectById<Person>(PersonId);
            return View(person);
        }
        [HttpPost]
        public async Task<IActionResult> DeletePerson(Person person)
        {
            await _repo.DeleteAsync(person);
            return RedirectToAction(nameof(Index));
        }
    }
}
