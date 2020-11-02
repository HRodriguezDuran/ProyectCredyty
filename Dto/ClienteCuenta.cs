using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCuentaBanco
{
    public class ClienteCuenta
    {
        public int? Numcuenta { get; set; }
        public string Tipotransaccion { get; set; }
        public int? Valortransaccion { get; set; }
        public int? Saldo { get; set; }
        public DateTime? Fechatransaccion { get; set; }
        public string Sucursal { get; set; }

    }
}
