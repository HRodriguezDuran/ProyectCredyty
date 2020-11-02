using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApiCuentaBanco.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiCuentaBanco.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCuentaBanco.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CuentaController));

        [HttpPost]
        public Respons PostCrearCliente(UsuarioCuenta usuario)
        {
            try
            {
                if (usuario.Nombre == string.Empty)
                {
                    return new Respons { Messagess = "Debe ingresar datos del cliente", Error = true };
                }

                var optionsBuilder = new DbContextOptionsBuilder<prueba_cContext>();
                optionsBuilder.UseSqlServer("server=172.16.1.64; database=prueba_c; User Id = pmasivos; Password=Pmasivos2020*");

                var context = new prueba_cContext(optionsBuilder.Options);
                context.Database.OpenConnection();

                var creaCliente = new Cliente()
                {
                    Nombre = usuario.Nombre,
                    Numcuenta = usuario.NumCuenta,
                    Telefono = Convert.ToString(usuario.Telefono),
                    Activa = usuario.Activa
                };
                context.Cliente.Add(creaCliente);
                context.SaveChanges();
                context.Database.CloseConnection();

                return new Respons { Messagess = "Cliente creado correctamente", Error = false };

            }
            catch (Exception exception)
            {
                log.Error(exception);
                throw new ApplicationException("Error en método PostCrearCuenta, ApiCuentaBanco", exception);

            }

        }


        [HttpPost]
        public Respons PostCrearCuenta(ClienteCuenta usuario)
        {
            try
            {
                if (usuario.Numcuenta == null)
                {
                    return new Respons { Messagess = "Debe ingresar datos del cliente", Error = true };
                }

                var optionsBuilder = new DbContextOptionsBuilder<prueba_cContext>();
                optionsBuilder.UseSqlServer("server=172.16.1.64; database=prueba_c; User Id = pmasivos; Password=Pmasivos2020*");

                var context = new prueba_cContext(optionsBuilder.Options);
                context.Database.OpenConnection();

                var creaCuenta = new Cuenta()
                {
                    Numcuenta = usuario.Numcuenta,
                    Tipotransaccion = usuario.Tipotransaccion,
                    Valortransaccion = usuario.Valortransaccion,
                    Saldo = usuario.Saldo,
                    Fechatransaccion = DateTime.Now,
                    Sucursal = usuario.Sucursal,

                };
                context.Cuenta.Add(creaCuenta);
                context.SaveChanges();
                context.Database.CloseConnection();

                return new Respons { Messagess = "Cuenta creada correctamente", Error = false };

            }
            catch (Exception exception)
            {
                log.Error(exception);
                throw new ApplicationException("Error en método PostCrearCuenta, ApiCuentaBanco", exception);

            }

        }

           [HttpPost]
        public Respons PostRealizaTransaccion(ClienteCuenta usuario)
        {
            try
            {
                if (usuario.Numcuenta == null)
                {
                    return new Respons { Messagess = "Debe ingresar datos del cliente, Error transacción", Error = true };
                }

                var optionsBuilder = new DbContextOptionsBuilder<prueba_cContext>();
                optionsBuilder.UseSqlServer("server=172.16.1.64; database=prueba_c; User Id = pmasivos; Password=Pmasivos2020*");

                var context = new prueba_cContext(optionsBuilder.Options);
                context.Database.OpenConnection();

                var cuentaUser = context.Cuenta.OrderByDescending(i => i.Fechatransaccion).Where(n=> n.Numcuenta== usuario.Numcuenta).First();

                var creaCuenta = new Cuenta()
                {
                    Numcuenta = usuario.Numcuenta,
                    Tipotransaccion = usuario.Tipotransaccion,
                    Valortransaccion = usuario.Valortransaccion,
                    Saldo = cuentaUser.Saldo - usuario.Valortransaccion,
                    Fechatransaccion = DateTime.Now,
                    Sucursal = usuario.Sucursal,

                };

                context.Cuenta.Add(creaCuenta);
                context.SaveChanges();
                context.Database.CloseConnection();

                return new Respons { Messagess = "Transacción exitosa", Error = false };

            }
            catch (Exception exception)
            {
                log.Error(exception);
                throw new ApplicationException("Error en método PostCrearCuenta, ApiCuentaBanco", exception);

            }

        }

        [HttpPost]
        public dynamic PostConsultarSaldo(ClienteCuenta usuario)
        {
            try
            {
                if (usuario.Numcuenta == null)
                {
                    return new Respons { Messagess = "Debe ingresar datos del cliente, Error transacción", Error = true };
                }

                var optionsBuilder = new DbContextOptionsBuilder<prueba_cContext>();
                optionsBuilder.UseSqlServer("server=172.16.1.64; database=prueba_c; User Id = pmasivos; Password=Pmasivos2020*");

                var context = new prueba_cContext(optionsBuilder.Options);
                context.Database.OpenConnection();
             
                var cuentaUser = context.Cuenta.OrderByDescending(i => i.Fechatransaccion).Where(n => n.Numcuenta == usuario.Numcuenta).First();

                var saldo = cuentaUser.Saldo;

                context.Database.CloseConnection();
                return saldo;

            }
            catch (Exception exception)
            {
                log.Error(exception);
                throw new ApplicationException("Error en método PostCrearCuenta, ApiCuentaBanco", exception);

            }

        }

    }
}
