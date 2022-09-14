
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaProjectFinalProject;
using SpaProjectFinalProject.Data;
using SpaProjectFinalProject.GenericRepo;
using SpaProjectFinalProject.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpaProjectFinalProject.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRepo _repo;

        public AnimalController(ApplicationDbContext dbContext, IRepo repo)
        {
            _dbContext = dbContext;
            _repo = repo;
        }
        /*********/
        #region ListAnimals
        public async Task<IActionResult> Index(string sortOrder, string Searchstring, int pg = 1)
        {

            var listOfAnimals = await _repo.SelectAsync<Animal>();

            //ViewBag.AnimalsDbPerson = new SelectList(await _repo.SelectAsync<Animal>(), "AnimalId", "Name");/*Waarom werkt deze */
            ////Sorteren
            ViewBag.NameSort = string.IsNullOrEmpty(sortOrder) ? "name_sort" : "";
            ViewBag.RaceSort = sortOrder == "Address" ? "address_sort" : "Address";
            ViewBag.BirthDate = string.IsNullOrEmpty(sortOrder) ? "BirthDate" : "";
            switch (sortOrder)
            {
                case "name_sort":
                    listOfAnimals = listOfAnimals.OrderByDescending(b => b.Name).ToList();
                    break;

                case "Race":
                    listOfAnimals = listOfAnimals.OrderBy(x => x.Race).ToList();
                    break;
                case "BirthDate":
                    listOfAnimals = listOfAnimals.OrderBy(x => x.BirthDate.ToString()).ToList();
                    break;
                default:
                    listOfAnimals = listOfAnimals.OrderBy(b => b.Name).ToList();
                    break;

            }
            //**************************************************Zoek optie
            if (!string.IsNullOrEmpty(Searchstring))
            {
                listOfAnimals = listOfAnimals.Where(x => x.Name.Contains(Searchstring, StringComparison.CurrentCultureIgnoreCase)).ToList();

            }
            ViewBag.Searchstring = Searchstring;
            //******************************************************paging
            const int pageSize = 9;
            if (pg < 1)//gebruikt in geval dat user kleiner wilt gaan dan 1 blijft hij op een.
            {
                pg = 1;
            }
            int recsCount = listOfAnimals.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = listOfAnimals.Skip(recSkip).Take(pageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);

        }
        #endregion
        /********/
        #region Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var animaldetails = await _repo.SelectById<Animal>(id);
                return View(animaldetails);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        #endregion
        /********/
        #region CreateFunctie
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Animal image, IFormFile uploadFile)
        {
            try
            {
                if (uploadFile != null && uploadFile.Length > 0)
                {
                    var fileName = Path.GetFileName(uploadFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    image.Path = filePath;
                    image.NamePath = fileName;
                    _dbContext.Animals.Add(image);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(fileStream);
                    }
                    await _repo.Create<Animal>(image);
                    _dbContext.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View("error happened");
            }
        }
        #endregion
        /********/
        #region DeleteFunctie
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _repo.SelectById<Animal>(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Animal animal)
        {
            await _repo.DeleteAsync(animal);
            return RedirectToAction(nameof(Index));
        }
        #endregion
        /********/
        #region ShowAnimalByAdoptionId
        [HttpGet]
        public async Task<IActionResult> ShowAnimalByAdoptionId(string sortOrder, int id, int pg=1)
        {

            try
            {
                //**********************************Id for AdoptionShelter
                ViewBag.Id = id;
                var adoptionShelter = await _repo.SelectAsync<Animal>();
                adoptionShelter.Where(x => x.AdoptionCenterId == id).ToList();
                //*********************************Sorting
                ViewBag.NameSort = string.IsNullOrEmpty(sortOrder) ? "name_sort" : "";
                ViewBag.RaceSort = string.IsNullOrEmpty(sortOrder) ? "Race" : "";
                ViewBag.BirthDate = string.IsNullOrEmpty(sortOrder) ? "BirthDate" : "";
                switch (sortOrder)
                {
                    case "name_sort":
                        adoptionShelter = adoptionShelter.OrderByDescending(b => b.Name).ToList();
                        break;

                    case "Race":
                        adoptionShelter = adoptionShelter.OrderBy(x => x.Race).ToList();
                        break;
                    case "BirthDate":
                        adoptionShelter = adoptionShelter.OrderBy(x => x.BirthDate.ToString()).ToList();
                        break;
                    default:
                        adoptionShelter = adoptionShelter.OrderBy(b => b.Name).ToList();
                        break;

                }
                //**************************************************Paging
                const int pageSize = 9;
                if (pg < 1)//gebruikt in geval dat user kleiner wilt gaan dan 1 blijft hij op een.
                {
                    pg = 1;
                }
                int recsCount = adoptionShelter.Count();
                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = adoptionShelter.Skip(recSkip).Take(pageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(data);
            }
            catch
            {
                return View("an error occured");
            }
        }
        #endregion

    }
}
