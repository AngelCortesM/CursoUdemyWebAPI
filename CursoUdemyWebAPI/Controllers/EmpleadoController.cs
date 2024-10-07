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
        private readonly IServicioEmpleado _servicioEmpleado;
        public EmpleadoController(IServicioEmpleado servicioEmpleado)
        {
            _servicioEmpleado = servicioEmpleado;
        }

        [HttpGet]
        public IEnumerable<EmpleadoDTO> DameEmpleados()
        {
            var listaEmpleados = _servicioEmpleado.DameEmpleados().Select(e => e.convertirDTO());
            return listaEmpleados;
        }
        [HttpGet("{codEmpleado}")]
        public ActionResult<EmpleadoDTO> DameEmpleado(string codEmpleado)
        {
            var empleado = _servicioEmpleado.DameEmpleado(codEmpleado).convertirDTO();
               if (empleado is null)
            { return NotFound(); }

            return empleado;
        }

        [HttpPost]
        public ActionResult<EmpleadoDTO> NuevoEmpleado(EmpleadoDTO e)
        {
            Empleado empleado = new Empleado
            {
                Id = _servicioEmpleado.DameEmpleados().Max(x => x.Id) + 1,
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
