using System.ComponentModel.DataAnnotations;

namespace CursoUdemyWebAPI.DTO
{
    public class EmpleadoDTO
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(4,ErrorMessage ="Maximo $ dígitos")]
        public string CodEmpleado { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato Incorrecto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Range(16,85,ErrorMessage ="La edad debe estar entre 16 y 85 años")]
        public int Edad { get; set; }
    }
}
