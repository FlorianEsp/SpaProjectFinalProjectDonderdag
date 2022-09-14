using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpaProjectFinalProject.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime
        {
            get
            {
                return this.StartTime.AddHours(1);
            }
            set { this.StartTime = value; }
        }
        //public DateTime EndTime { get; set; }
        //Relational Data 
        public virtual Animal Animal { get; set; }
        public virtual ApplicationUser User { get; set; }
        //constructor
        public Event(IFormCollection form, Animal animal, ApplicationUser user)
        {

            //Id = int.Parse(form["Event.Id"].ToString());
            User = user;
            Name = form["Event.Name"].ToString();
            Description = form["Event.Description"].ToString();
            StartTime = DateTime.Parse(form["Event.StartTime"].ToString());
            //EndTime = DateTime.Parse(form["Event.EndTime"].ToString());
            Animal = animal;

        }
        public void UpdateEvent(IFormCollection form, Animal animal, ApplicationUser user)
        {
            //Id = int.Parse(form["Event.Id"].ToString());
            User = user;
            Name = form["Event.Name"].ToString();
            Description = form["Event.Description"].ToString();
            StartTime = DateTime.Parse(form["Event.StartTime"].ToString());
            //EndTime = DateTime.Parse(form["Event.EndTime"].ToString());
            Animal = animal;
        }
        public Event()
        {

        }
    }
}
