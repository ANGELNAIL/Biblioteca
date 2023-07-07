namespace Biblioteca.Models
{
    public class Prestamo
    {
        public Int32 IdPrestamo { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaEsperada { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public String Estado { get; set; }
        public Int32 IdCliente { get; set; }
        public Int32 IdBibliotecario { get; set; }
    }
}
