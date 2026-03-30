using System.ComponentModel.DataAnnotations;

namespace FarmaciaWeb.Models
{
    public class Estante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Ubicación")]
        public string? Ubicacion { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        public ICollection<Medicamento>? Medicamentos { get; set; }
    }
}