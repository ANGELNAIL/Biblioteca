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
    public class BibliotecarioController : ControllerBase
    {
        [HttpGet("Bibliotecario_Get"), AllowAnonymous]
        public async Task<IActionResult> Bibliotecario_Get()
        {
            try
            {
                List<Bibliotecario> bibliotecarios = new List<Bibliotecario>();
                DbBibliotecario bibliotecario = new DbBibliotecario();
                DataSet ODs = await Task.Run(() => bibliotecario.Bibliotecario_Get());
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    bibliotecarios.Add(new Bibliotecario
                    {
                        IdBibliotecario = Convert.ToInt32(ds["IdBibliotecario"]),
                        Nombre = ds["Nombre"].ToString(),
                        APaterno = ds["APaterno"].ToString(),
                        AMaterno = ds["AMaterno"].ToString()
                    });
                }
                return Ok(bibliotecarios);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Bibliotecario_GetById")]
        public async Task<IActionResult> Bibliotecario_GetById(Int32 ID)
        {
            try
            {
                List<Bibliotecario> bibliotecarios = new List<Bibliotecario>();
                DbBibliotecario obibliotecario = new DbBibliotecario();
                DataSet ODs = await Task.Run(() => obibliotecario.Bibliotecario_GetById(ID));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    bibliotecarios.Add(new Bibliotecario
                    {
                        IdBibliotecario = Convert.ToInt32(ds["IdBibliotecario"]),
                        Nombre = ds["Nombre"].ToString(),
                        APaterno = ds["APaterno"].ToString(),
                        AMaterno = ds["AMaterno"].ToString()
                    });
                }
                return Ok(bibliotecarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Bibliotecario_Ins")]
        public async Task<IActionResult> Bibliotecario_Ins(DbBibliotecario bibliotecario)
        {
            try
            {
                DbUsuario usuario = new DbUsuario();
                usuario.Nombre = bibliotecario.Nombre + bibliotecario.APaterno + bibliotecario.AMaterno;
                usuario.Contrasenia = Security.RandomPassword();
                usuario.Rol = "Bibliotecario";
                bibliotecario.IdUsuario = await Task.Run(() => usuario.Usuario_Ins());
                NewBibliotecario bibliotecarios = new NewBibliotecario();
                bibliotecarios.Id = bibliotecario.Bibliotecario_Ins();
                bibliotecarios.Contrasena = usuario.Contrasenia;
                return Ok(bibliotecarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("Bibliotecario_Upd")]
        public async Task<IActionResult> Bibliotecario_Upd(DbBibliotecario bibliotecario)
        {
            try
            {
                await Task.Run(() => bibliotecario.Bibliotecario_Upd());
                return Ok("Datos Actualizados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        private class NewBibliotecario 
        {
            public Int32 Id { get; set; }
            public String Contrasena { get; set; }
        }
    }
}
