using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaWeb.Models
{
    public class Medicamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        [Display(Name = "Precio")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
        [Display(Name = "Fecha de Vencimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; } = true;

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        [Required(ErrorMessage = "El estante es obligatorio")]
        [Display(Name = "Estante")]
        public int EstanteId { get; set; }
        public Estante? Estante { get; set; }
    }
}