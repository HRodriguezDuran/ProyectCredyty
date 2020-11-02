using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCuentaBanco.Dto
{
    public class UsuarioCuenta
    {
        public int NumCuenta { get; set; }
        public string Nombre{ get; set; }
        public int Telefono { get; set; }

        public string Activa { get; set; }

    }
}
