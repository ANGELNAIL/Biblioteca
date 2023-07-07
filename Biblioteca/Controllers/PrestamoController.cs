using Biblioteca.BbContext;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        [HttpGet("Prestamo_Get")]
        public async Task<IActionResult> Prestamo_Get()
        {
            try
            {
                List<Prestamos> Prestamos = new List<Prestamos>();
                DbPrestamo Prestamo = new DbPrestamo();
                DataSet ODs = await Task.Run(() => Prestamo.Prestamo_Get());
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Prestamos.Add(new Prestamos
                    {
                        IdPrestamo = Convert.ToInt32(ds["IdPrestamo"]),
                        Cliente = ds["Cliente"].ToString(),
                        Bibliotecario =ds["Bibliotecario"].ToString(),
                        FechaPrestamo =Convert.ToDateTime(ds["FechaPrestamo"]),
                        FechaEsperada = Convert.ToDateTime(ds["FechaEsperada"]),
                        FechaDevolucion =Convert.ToDateTime(ds["FechaDevolucion"])
                    });
                }
                return Ok(Prestamos);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Prestamo_GetById")]
        public async Task<IActionResult> Prestamo_GetById(Int32 ID)
        {
            try
            {
                List<Prestamo> Prestamos = new List<Prestamo>();
                DbPrestamo oPrestamo = new DbPrestamo();
                DataSet ODs = await Task.Run(() => oPrestamo.Prestamo_GetById(ID));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Prestamos.Add(new Prestamo
                    {
                        IdPrestamo = Convert.ToInt32(ds["IdPrestamo"]),
                        IdCliente =Convert.ToInt32(ds["IdCliente"]),
                        IdBibliotecario =Convert.ToInt32(ds["IdBibliotecario"]),
                        FechaPrestamo = Convert.ToDateTime(ds["FechaPrestamo"]),
                        FechaEsperada = Convert.ToDateTime(ds["FechaEsperada"]),
                        FechaDevolucion = Convert.ToDateTime(ds["FechaDevolucion"])
                    });
                }
                return Ok(Prestamos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Prestamo_GetByCliente")]
        public async Task<IActionResult> Prestamo_GetByCliente(Int32 ID)
        {
            try
            {
                List<Prestamos> Prestamos = new List<Prestamos>();
                DbPrestamo oPrestamo = new DbPrestamo();
                DataSet ODs = await Task.Run(() => oPrestamo.Prestamo_GetByCliente(ID));
                foreach (DataRow ds in ODs.Tables[0].Rows)
                {
                    Prestamos.Add(new Prestamos
                    {
                        IdPrestamo = Convert.ToInt32(ds["IdPrestamo"]),
                        Cliente = ds["Cliente"].ToString(),
                        Bibliotecario = ds["Bibliotecario"].ToString(),
                        FechaPrestamo = Convert.ToDateTime(ds["FechaPrestamo"]),
                        FechaEsperada = Convert.ToDateTime(ds["FechaEsperada"]),
                        FechaDevolucion = Convert.ToDateTime(ds["FechaDevolucion"])
                    });
                }
                return Ok(Prestamos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Prestamo_Ins")]
        public async Task<IActionResult> Prestamo_Ins(DbPrestamo Prestamo)
        {
            try
            {
                Int32 Id = await Task.Run(() => Prestamo.Prestamo_Ins());
                return Ok(Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("Prestamo_Upd")]
        public async Task<IActionResult> Prestamo_Upd(DbPrestamo Prestamo)
        {
            try
            {
                await Task.Run(() => Prestamo.Prestamo_Upd());
                return Ok("Datos Actualizados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        private class Prestamos 
        {
            public Int32 IdPrestamo { get; set; }
            public string? Cliente { get; set; }
            public string? Bibliotecario { get; set; }
            public DateTime? FechaPrestamo { get; set; } 
            public DateTime? FechaEsperada { get; set; } 
            public DateTime? FechaDevolucion { get; set; } 
        }
    }
}
