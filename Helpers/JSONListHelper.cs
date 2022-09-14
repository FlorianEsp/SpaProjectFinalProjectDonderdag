using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaProjectFinalProject.Helpers
{
    public static class JSONListHelper
    {
        /*Change from c# to Json*/
        public static string GetEventListJSONString(List<Models.Event> events)/*from event just below*/
        {
            var eventlist = new List<Event>();
            foreach (var model in events)
            {
                var myevent = new Event()
                {
                    id = model.Id,
                    start = model.StartTime,
                    end = model.EndTime,
                    resourceId = model.Animal.AnimalId,
                    description = model.Description,
                    title = $"{model.Name} goes to visit {model.Animal.Name}"
                    /*fields are required or it breaks*/
                };
                eventlist.Add(myevent);
            }
            return System.Text.Json.JsonSerializer.Serialize(eventlist);/*omzetten naar Json*/
        }

        public static string GetResourceListJSONString(List<Models.Animal> animal)
        {
            var resourcelist = new List<Resource>();

            foreach (var loc in animal)
            {
                var resource = new Resource()
                {
                    id = loc.AnimalId,
                    title = loc.Name
                };
                resourcelist.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(resourcelist);
        }
    }

    public class Event
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int resourceId { get; set; }
        public string description { get; set; }
    }

    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }

    }
}

