using Unidad2Actividad1.Models.Etities;

namespace Unidad2Actividad1.Models.ViewModels
{
    public class IndexClaseViewModel
    {
        public int Id { get; set; }

        public string NombreA { get; set; } = null!;

        public ICollection<Especies> ListaEspecie { get; set; } = null!;
    }
}
