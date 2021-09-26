using InyeccionDependencias.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InyeccionDependencias.Pages
{
    public class IndexModel : PageModel
    {
        public IEmailService EmailService { get; }
        public IndexModel(IEmailService emailService)
        {
            EmailService = emailService;
        }

        public string Mensaje { get; set; }

        public void OnGet([FromServices] IEmailService Email)
        {
            //Mensaje = EmailService.EnviarCorreo();
            Mensaje = Email.EnviarCorreo(); 
        }
    }
}
