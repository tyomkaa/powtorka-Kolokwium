using System;

namespace Kolokwium_powtórka.Models
{
    public class Animal
    {
        public int idAnimal { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int idOwner { get; set; }
        public Owner Owner { get; set; }
    }
}
