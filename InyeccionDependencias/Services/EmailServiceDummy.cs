using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InyeccionDependencias.Services
{
    public class EmailServiceDummy : IEmailService
    {
        public string EnviarCorreo()
        {
            return "Mensaje enviado";
        }
    }
}
