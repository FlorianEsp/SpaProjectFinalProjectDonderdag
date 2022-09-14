using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SpaProjectFinalProject.Models.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        //make dropdownList 
        public List<SelectListItem> AnimalsList = new List<SelectListItem>();
        public string AnimalsName { get; set; }
        public string UserId { get; set; }
        public EventViewModel(Event myEvent, List<Animal> events, string userid)//crash because AnimalId is null
        {
            Event = myEvent;
            AnimalsName = myEvent.Animal.Name;
            UserId = userid;
            foreach (var e in events)
            {
                AnimalsList.Add(new SelectListItem() { Text = e.Name });
            }

        }
        public EventViewModel(List<Animal> events, string userid)
        {
            UserId = userid;
            foreach (var e in events)
            {
                AnimalsList.Add(new SelectListItem() { Text = e.Name });
            }
        }
        public EventViewModel()
        {

        }
    }
}
