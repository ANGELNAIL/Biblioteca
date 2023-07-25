using Biblioteca.BbContext;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("Usuario_Ins")]
        public Int32 Usuario_Ins(DbUsuario usuario)
        {
            Int32 Id = usuario.Usuario_Ins();
            return Id;
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login(String Entrada,String Pass)
        {
            try
            {
                List<Usuario> usuario = new List<Usuario>();
                DbUsuario oUsuario = new DbUsuario();
                DataSet ODs = await Task.Run(() => oUsuario.Login(Entrada));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    if (!string.IsNullOrEmpty(ds["IdUsuario"].ToString()))
                    {
                        if (ds["Contrasenia"].ToString() == Pass)
                        {
                            usuario.Add(new Usuario
                            {
                                IdUsuario = Convert.ToInt32(ds["IdUsuario"]),
                                Nombre = ds["Nombre"].ToString(),
                                Correo = ds["Correo"].ToString(),
                                Rol = ds["Rol"].ToString()
                            });
                        }
                        else
                        {
                        return BadRequest("Contraseña incorrecta");
                        }
                    }
                    else 
                    {
                        return BadRequest("Usuario no encontrado");
                    }
                }
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Usuario_GetById")]
        public async Task<IActionResult> Usuario_GetById(Int32 Id)
        {
            try
            {
                List<Usuario> usuario = new List<Usuario>();
                DbUsuario oUsuario = new DbUsuario();
                DataSet ODs = await Task.Run(() => oUsuario.Usuario_GetById(Id));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    if (!string.IsNullOrEmpty(ds["IdUsuario"].ToString()))
                    {
                        usuario.Add(new Usuario
                        {
                            IdUsuario = Convert.ToInt32(ds["IdUsuario"]),
                            Nombre = ds["Nombre"].ToString(),
                            Correo = ds["Correo"].ToString(),
                            Contrasenia = ds["Contrasenia"].ToString(),
                            Rol="",
                            Estado=""
                        });
                    }
                }
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("Usuario_Upd")]
        public async Task<IActionResult> Usuario_Upd(DbUsuario usuario)
        {
            try
            {
                await Task.Run(() => usuario.Usuario_Upd());
                return Ok("Se ha actualizado la informacion");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
