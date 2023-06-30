using Biblioteca.BbContext;
using Biblioteca.Models;
using Biblioteca.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        [HttpGet("Contacto_Get"), AllowAnonymous]
        public async Task<IActionResult> Contacto_Get()
        {
            try
            {
                List<Contacto> Contactos = new List<Contacto>();
                DbContacto Contacto = new DbContacto();
                DataSet ODs = await Task.Run(() => Contacto.Contacto_Get());
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Contactos.Add(new Contacto
                    {
                        IdContacto = Convert.ToInt32(ds["IdContacto"]),
                        IdCliente = Convert.ToInt32(ds["IdCliente"]),
                        Celular = ds["Celular"].ToString(),
                        Telefono = ds["Telefono"].ToString(),
                        Correo = ds["Correo"].ToString()
                    });
                }
                return Ok(Contactos);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Contacto_GetById")]
        public async Task<IActionResult> Contacto_GetById(Int32 ID)
        {
            try
            {
                List<Contacto> Contactos = new List<Contacto>();
                DbContacto oContacto = new DbContacto();
                DataSet ODs = await Task.Run(() => oContacto.Contacto_GetById(ID));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Contactos.Add(new Contacto
                    {
                        IdContacto = Convert.ToInt32(ds["IdContacto"]),
                        IdCliente = Convert.ToInt32(ds["IdCliente"]),
                        Celular = ds["Celular"].ToString(),
                        Telefono = ds["Telefono"].ToString(),
                        Correo = ds["Correo"].ToString()
                    });
                }
                return Ok(Contactos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Contacto_GetByCliente")]
        public async Task<IActionResult> Contacto_GetByCliente(Int32 ID)
        {
            try
            {
                List<Contacto> Contactos = new List<Contacto>();
                DbContacto oContacto = new DbContacto();
                DataSet ODs = await Task.Run(() => oContacto.Contacto_GetByCliente(ID));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Contactos.Add(new Contacto
                    {
                        IdContacto = Convert.ToInt32(ds["IdContacto"]),
                        IdCliente = Convert.ToInt32(ds["IdCliente"]),
                        Celular = ds["Celular"].ToString(),
                        Telefono = ds["Telefono"].ToString(),
                        Correo = ds["Correo"].ToString()
                    });
                }
                return Ok(Contactos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Contacto_Ins")]
        public async Task<IActionResult> Contacto_Ins(DbContacto Contacto)
        {
            try
            {
                Int32 Id = await Task.Run(() => Contacto.Contacto_Ins());
                return Ok(Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("Contacto_Upd")]
        public async Task<IActionResult> Contacto_Upd(DbContacto Contacto)
        {
            try
            {
                await Task.Run(() => Contacto.Contacto_Upd());
                return Ok("Datos Actualizados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
