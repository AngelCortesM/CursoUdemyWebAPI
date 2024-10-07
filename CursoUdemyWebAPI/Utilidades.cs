using CursoUdemyWebAPI.DTO;

namespace CursoUdemyWebAPI
{
    public static class Utilidades
    {
        public static EmpleadoDTO convertirDTO(this Empleado e)
        {
            if (e != null)
            {
                return new EmpleadoDTO
                {
                    Nombre = e.Nombre,
                    CodEmpleado = e.CodEmpleado,
                    Email = e.Email,
                    Edad = e.Edad

                };
            }
            return null;
        }
    }
}
