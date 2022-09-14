using DotNetCoreCalendar.Controllers.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaProjectFinalProject.Data;
using SpaProjectFinalProject.GenericRepo;
using SpaProjectFinalProject.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpaProjectFinalProject.Controllers
{
    public class AnimalLostController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRepo _repo;

        public AnimalLostController(ApplicationDbContext dbContext, IRepo repo)
        {
            _dbContext = dbContext;
            _repo = repo;
        }
        #region ListLostAnimals
        public async Task<IActionResult> LostAnimalIndex(int pg)
        {

            var listOfLostAnimals = await _repo.SelectAsync<AnimalLost>();
            //Paging
            const int pageSize = 6;
            if (pg < 1)//gebruikt in geval dat user kleiner wilt gaan dan 1 blijft hij op een.
            {
                pg = 1;
            }
            int recsCount = listOfLostAnimals.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = listOfLostAnimals.Skip(recSkip).Take(pageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);
        }
        #endregion
        /********/
        #region CreateLostAnimalFunctie
        public IActionResult LostAnimalCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LostAnimalCreate(AnimalLost animal, IFormFile uploadFile)
        {
            if (uploadFile != null && uploadFile.Length > 0)
            {
                var fileName = Path.GetFileName(uploadFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                animal.Path = filePath;
                animal.NamePath = fileName;
                await _dbContext.AnimalsLost.AddAsync(animal);

                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(fileSrteam);
                }
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(LostAnimalIndex));
        }
        #endregion
      
    }
}
