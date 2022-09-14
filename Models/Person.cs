using System.Collections.Generic;

namespace SpaProjectFinalProject.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public bool HaveAnimal { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public virtual ICollection<AnimalLost> AnimalLost { get; set; }

    }
}
