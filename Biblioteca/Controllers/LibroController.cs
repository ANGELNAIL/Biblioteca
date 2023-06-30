using Biblioteca.BbContext;
using Biblioteca.Models;
using Biblioteca.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        [HttpGet("Libro_Get"), AllowAnonymous]
        public async Task<IActionResult> Libro_Get()
        {
            try
            {
                List<Libro> Libros = new List<Libro>();
                DbLibro Libro = new DbLibro();
                DataSet ODs = await Task.Run(() => Libro.Libro_Get());
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Libros.Add(new Libro
                    {
                        IdLibro = Convert.ToInt32(ds["IdLibro"]),
                        Nombre = ds["Nombre"].ToString(),
                        Editorial = ds["Editorial"].ToString(),
                        Inventario = Convert.ToInt32(ds["Inventario"]),
                        Genero = ds["Genero"].ToString(),
                        Autor = ds["Autor"].ToString()
                    });
                }
                return Ok(Libros);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Libro_GetById")]
        public async Task<IActionResult> Libro_GetById(Int32 ID)
        {
            try
            {
                List<Libro> Libros = new List<Libro>();
                DbLibro oLibro = new DbLibro();
                DataSet ODs = await Task.Run(() => oLibro.Libro_GetById(ID));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Libros.Add(new Libro
                    {
                        IdLibro = Convert.ToInt32(ds["IdLibro"]),
                        Nombre = ds["Nombre"].ToString(),
                        Editorial = ds["Editorial"].ToString(),
                        Inventario = Convert.ToInt32(ds["Inventario"]),
                        Genero = ds["Genero"].ToString(),
                        Autor = ds["Autor"].ToString()
                    });
                }
                return Ok(Libros);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Libro_Autor")]
        public async Task<IActionResult> Libro_Autor(string NombreAutor)
        {
            try
            {
                List<Libro> Libros = new List<Libro>();
                DbLibro oLibro = new DbLibro();
                DataSet ODs = await Task.Run(() => oLibro.Libro_Autor(NombreAutor));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Libros.Add(new Libro
                    {
                        IdLibro = Convert.ToInt32(ds["IdLibro"]),
                        Nombre = ds["Nombre"].ToString(),
                        Editorial = ds["Editorial"].ToString(),
                        Inventario = Convert.ToInt32(ds["Inventario"]),
                        Genero = ds["Genero"].ToString(),
                        Autor = ds["Autor"].ToString()
                    });
                }
                return Ok(Libros);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Libro_Genero")]
        public async Task<IActionResult> Libro_Genero(string NombreGenero)
        {
            try
            {
                List<Libro> Libros = new List<Libro>();
                DbLibro oLibro = new DbLibro();
                DataSet ODs = await Task.Run(() => oLibro.Libro_Autor(NombreGenero));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Libros.Add(new Libro
                    {
                        IdLibro = Convert.ToInt32(ds["IdLibro"]),
                        Nombre = ds["Nombre"].ToString(),
                        Editorial = ds["Editorial"].ToString(),
                        Inventario = Convert.ToInt32(ds["Inventario"]),
                        Genero = ds["Genero"].ToString(),
                        Autor = ds["Autor"].ToString()
                    });
                }
                return Ok(Libros);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Libro_Editorial")]
        public async Task<IActionResult> Libro_Editorial(string NombreEditorial)
        {
            try
            {
                List<Libro> Libros = new List<Libro>();
                DbLibro oLibro = new DbLibro();
                DataSet ODs = await Task.Run(() => oLibro.Libro_Editorial(NombreEditorial));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Libros.Add(new Libro
                    {
                        IdLibro = Convert.ToInt32(ds["IdLibro"]),
                        Nombre = ds["Nombre"].ToString(),
                        Editorial = ds["Editorial"].ToString(),
                        Inventario = Convert.ToInt32(ds["Inventario"]),
                        Genero = ds["Genero"].ToString(),
                        Autor = ds["Autor"].ToString()
                    });
                }
                return Ok(Libros);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Libro_Ins")]
        public async Task<IActionResult> Libro_Ins(DbLibro Libro)
        {
            try
            {
                Int32 Id = await Task.Run(() => Libro.Libro_Ins());
                return Ok(Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("Libro_Upd")]
        public async Task<IActionResult> Libro_Upd(DbLibro Libro)
        {
            try
            {
                await Task.Run(() => Libro.Libro_Upd());
                return Ok("Datos Actualizados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
