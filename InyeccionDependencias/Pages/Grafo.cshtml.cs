using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InyeccionDependencias.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InyeccionDependencias.Pages
{
    public class GrafoModel : PageModel
    {
        public GrafoModel(IServicioA servicioA)
        {
            ServicioA = servicioA;
            MensajeDelServicio = servicioA.ObtenerMensaje();
        }
        public string MensajeDelServicio { get; private set; }

        public IServicioA ServicioA { get; }

        public void OnGet()
        {
        }
    }
}
