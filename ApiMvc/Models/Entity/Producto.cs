using ApiMvc.Models.Cores.Model;

namespace ApiMvc.Models.Entity
{
    public class Producto : CoreModel
    {
        public string Nombre { get; set; } = string.Empty; // Se inicializa 'Nombre' con una cadena vacía y se pone string? si sea null
        public double Precio { get; set; }
        public int FabricanteId { get; set; }

        public virtual Fabricante? Fabricante { get; set; }
    }
}
