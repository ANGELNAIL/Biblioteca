using Biblioteca.BbContext;
using Biblioteca.Models;
using Biblioteca.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;
using System.Xml;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("Cliente_Get"), AllowAnonymous]
        public async Task<IActionResult> Cliente_Get()
        {
            try
            {
                List<Cliente> Clientes = new List<Cliente>();
                DbCliente Cliente = new DbCliente();
                DataSet ODs = await Task.Run(() => Cliente.Cliente_Get());
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Clientes.Add(new Cliente
                    {
                        IdCliente = Convert.ToInt32(ds["IdCliente"]),
                        Nombre = ds["Nombre"].ToString(),
                        APaterno = ds["APaterno"].ToString(),
                        AMaterno = ds["AMaterno"].ToString(),
                        Celular = ds["Celular"].ToString(),
                        Telefono = ds["Telefono"].ToString()
                    });
                }
                return Ok(Clientes);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Cliente_GetById")]
        public async Task<IActionResult> Cliente_GetById(Int32 ID)
        {
            try
            {
                List<Cliente> Clientes = new List<Cliente>();
                DbCliente oCliente = new DbCliente();
                DataSet ODs = await Task.Run(() => oCliente.Cliente_GetById(ID));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Clientes.Add(new Cliente
                    {
                        IdCliente = Convert.ToInt32(ds["IdCliente"]),
                        Nombre = ds["Nombre"].ToString(),
                        APaterno = ds["APaterno"].ToString(),
                        AMaterno = ds["AMaterno"].ToString(),
                        Telefono = ds["Telefono"].ToString(),
                        Celular = ds["Celular"].ToString()
                    });
                }
                return Ok(Clientes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Cliente_Ins")]
        public async Task<IActionResult> Cliente_Ins(DbCliente Cliente)
        {
            try
            {
                DbUsuario Usuario = new DbUsuario();
                Usuario.Nombre = Cliente.NombreU;
                Usuario.Contrasenia = Cliente.Contrasenia;
                Usuario.Correo = Cliente.Correo;
                Usuario.Rol = "Usuario";
                Cliente.IdUsuario = await Task.Run(() => Usuario.Usuario_Ins());
                Int32 Id = Cliente.Cliente_Ins();
                return Ok(Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("Cliente_Upd")]
        public async Task<IActionResult> Cliente_Upd(DbCliente Cliente)
        {
            try
            {
                await Task.Run(() => Cliente.Cliente_Upd());
                return Ok("Datos Actualizados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("Cliente_Del")]
        public async Task<IActionResult> Cliente_Del(Int32 Id)
        {
            try
            {
                DbCliente cliente = new DbCliente();
                await Task.Run(() => cliente.Cliente_Del(Id));
                return Ok("Datos eliminados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
