using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpaProjectFinalProject.Data;
using SpaProjectFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaProjectFinalProject.Services
{
 
    public interface IDAl
    {
        public Task<List<Event>> GetEvents();
        public Task<List<Event>> GetMyEvents(string userId);//by default user id is an string
        public Task<Event> GetEvent(int id);
        public Task CreateEvent(IFormCollection form);
        public Task UpdateEvent(IFormCollection form); //give you a list from everything
        public Task DeleteEvent(int id);
        public Task<List<Animal>> GetAnimals();
        public Task<Animal> GetAnimalById(int id);
        public Task CreateAnimal(Animal animal);
    }
    public class DAL : IDAl
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Task<List<Event>> GetEvents()
        {
            return db.Event.ToListAsync();
        }
        public async Task<List<Event>> GetMyEvents(string userId)
        {
            return await db.Event.Where(x => x.User.Id == userId).ToListAsync();
        }

        public async Task<Event> GetEvent(int id)
        {
            return await db.Event.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateEvent(IFormCollection form)
        //form is string so you have to convert
        {
            var animalName = form["Animal"].ToString();
            var user = db.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            var newEvent = new Event(form, db.Animals.FirstOrDefault(x => x.Name == animalName), user);
            db.Event.Add(newEvent);
            await db.SaveChangesAsync();

        }
        public async Task UpdateEvent(IFormCollection form)
        {
            var animalName = form["AnimalsList"].ToString();

            var eventId = int.Parse(form["Event.Id"]);
            var myEvent = db.Event.FirstOrDefault(w => w.Id == eventId);
            var user = db.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            var animal = db.Animals.FirstOrDefault(x => x.Name == animalName);
            myEvent.UpdateEvent(form, animal, user);
            db.Entry(myEvent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
        }
        public async Task DeleteEvent(int id)
        {
            var myEvent = db.Event.Find(id);
            db.Event.Remove(myEvent);
            await db.SaveChangesAsync();
        }
        public async Task<List<Animal>> GetAnimals()
        {
            return await db.Animals.ToListAsync();
        }
        public async Task<Animal> GetAnimalById(int id)
        {
            return await db.Animals.FindAsync(id);
        }
        public async Task CreateAnimal(Animal animal)
        {
            db.Animals.Add(animal);
            await db.SaveChangesAsync();
        }


    }
}
