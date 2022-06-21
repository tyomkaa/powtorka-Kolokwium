using System;

namespace Kolokwium_powtórka.Models
{
    public class Procedure_Animal
    {
        public int idProcedure { get; set; }
        public Procedure Procedure { get; set; }
        public int idAnimal { get; set; }
        public Animal Animal { get; set; }
        public DateTime Date { get; set; }
    }
}
