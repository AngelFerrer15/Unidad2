namespace Unidad2Actividad1.Models.ViewModels
{
    public class DetallesAnimalViewModel
    {
        public int Id { get; set; }

        public string Especie { get; set; } = null!;

        public double PesoAnimal { get; set; }

        public string ClaseAnimal { get; set; } = null!;

        public int TamañoAnimal { get; set; }

        public string DescripcionDeAnimal { get; set; } = null!;

        public string HabitatAnimal { get; set; } = null!;

       
    }
}
