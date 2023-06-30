namespace Biblioteca.Models
{
    public class Libro
    {
        public Int32? IdLibro { get; set; }
        public String Nombre { get; set; }
        public String Editorial { get; set; }
        public Int32 Inventario { get; set; }
        public String Genero { get; set; }
        public string Autor { get; set; }   
        public String? Estado { get; set; }

    }
}
