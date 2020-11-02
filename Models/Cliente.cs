using System;
using System.Collections.Generic;

namespace ApiCuentaBanco.Models
{
    public partial class Cliente
    {
        public int Numcuenta { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Activa { get; set; }
    }
}
