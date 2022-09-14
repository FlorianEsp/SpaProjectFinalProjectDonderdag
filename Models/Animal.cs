using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpaProjectFinalProject.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }

        public string Description { get; set; }
        public bool IsVaccinated { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Path { get; set; }
        public string NamePath { get; set; }
        [Display(Name = "Is your Animal Lost")]
        [Range(typeof(bool), "true", "true")]
        public bool Terms { get; set; }
        public bool IsLost { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public int? AdoptionCenterId { get; set; }
        public virtual AdoptionCenter AdoptionCenter { get; set; }

    }
}
