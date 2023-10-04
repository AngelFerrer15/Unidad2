using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unidad2Actividad1.Models.Etities;
using Unidad2Actividad1.Models.ViewModels;

namespace Unidad2Actividad1.Controllers
{

    
    public class HomeController : Controller
    {
        private AnimalesContext c = new ();
        public IActionResult Index()
        {
            IndexViewModel vm = new ();
            var dat = c.Clase.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
            {
                Id = x.Id,
                NombreC = x.Nombre ?? "",
                Descripcion = x.Descripcion ?? "",
            }).AsEnumerable();

            return View(dat);
        }

        public IActionResult ClasA (string id)
        {
            var cla = c.Clase.Include(x => x.Especies).Select(x => new IndexClaseViewModel
            {
                Id = x.Id,
                NombreA = x.Nombre ?? "",
                ListaEspecie = x.Especies
            }).FirstOrDefault(x => x.NombreA == id.Replace('-', ' '));
            return View(cla);
        }

        public IActionResult Deta(string id)
        {
            id = id.Replace("-", " ");

            var temp = c.Especies.Include(x => x.IdClaseNavigation)
               .Where(x => x.Especie.ToLower() == id.ToLower()).FirstOrDefault();

            if (temp == null)
            {
                return RedirectToAction("Index");
            }

            else
            {
                DetallesAnimalViewModel vm = new()
                {
                    Id = temp.Id,
                    Especie = temp.Especie,
                    ClaseAnimal = temp.IdClaseNavigation != null ? temp.IdClaseNavigation.Nombre ?? "" : "",
                    PesoAnimal = (double)(temp.Peso ?? 0),
                    TamañoAnimal = temp.Tamaño ?? 0,
                    HabitatAnimal = temp.Habitat ?? "",
                    DescripcionDeAnimal = temp.Observaciones ?? ""
                };
                return View(vm);
            }

        }
    }
}
