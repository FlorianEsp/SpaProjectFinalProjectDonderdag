using System.Collections.Generic;

namespace SpaProjectFinalProject.Models
{
    public class AdoptionCenter
    {
        public int AdoptionCenterId { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public int Rate { get; set; }
        public string PhoneNumber { get; set; }
        public string PostCode { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
        //Relational Data
    }
}
