using CursoUdemyWebAPI.DTO;
using CursoUdemyWebAPI.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoUdemyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IServicioEmpleadoSQL _servicioEmpleado;
        public EmpleadoController(IServicioEmpleadoSQL servicioEmpleado)
        {
            _servicioEmpleado = servicioEmpleado;
        }

        [HttpGet]
        [Route("variosEmpleados")]
        public IEnumerable<EmpleadoDTO> DameEmpleados()
        {
            var listaEmpleados = _servicioEmpleado.DameEmpleados().Select(e => e.convertirDTO());
            return listaEmpleados;
        }


        [HttpGet("1Empleado/{codEmpleado}")]
        public ActionResult<EmpleadoDTO> DameEmpleado(string codEmpleado)
        {
            var empleado = _servicioEmpleado.DameEmpleado(codEmpleado).convertirDTO();
               if (empleado is null)
            { return NotFound("Empleado no encontrado"); }

            return empleado;
        }

  
        [HttpPost]
        [Route("nuevoEmpleado")]
        public ActionResult<EmpleadoDTO> NuevoEmpleado(EmpleadoDTO e)
        {
            Empleado empleado = new Empleado
            {
                    
                CodEmpleado = e.CodEmpleado,
                Nombre = e.Nombre,
                Email = e.Email,
                Edad = e.Edad,
                FechaAlta = DateTime.Now
            };

            _servicioEmpleado.NuevoEmpleado(empleado);
            return empleado.convertirDTO();
        }

  
        [HttpPut]
        [Route("modificarEmpleado")]
        public ActionResult<EmpleadoDTO> ModificarEmpleado(EmpleadoDTO e)
        {
            var empleadoAux = _servicioEmpleado.DameEmpleado(e.CodEmpleado);
            if (empleadoAux is null)
            {
                return NotFound();
            }
            empleadoAux.CodEmpleado = e.CodEmpleado; 
            empleadoAux.Nombre = e.Nombre;
            empleadoAux.Email = e.Email;
            empleadoAux.Edad = e.Edad;

       

            _servicioEmpleado.ModificarEmpleado(empleadoAux);
            return e;
        }

    
        [HttpDelete]
        [Route("eliminarEmpleado")]
        public ActionResult BajaEmpleado(string codEmpleado)
        {
            var empleadoAux = _servicioEmpleado.DameEmpleado(codEmpleado);
            if (empleadoAux is null)
            {
                return NotFound();
            }
            _servicioEmpleado.BajaEmpleado(codEmpleado);
            return Ok();
        }
    }
}
