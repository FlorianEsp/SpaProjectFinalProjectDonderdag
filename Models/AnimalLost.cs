using System;

namespace SpaProjectFinalProject.Models
{
    public class AnimalLost
    {
        public int AnimalLostId { get; set; }
        public string AnimalLostName { get; set; }
        public string AnimalLostDescription { get; set; }
        public DateTime DateLost { get; set; }
        public string Path { get; set; }
        public string NamePath { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

    }
}
