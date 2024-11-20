
namespace CursoUdemyWebAPI.Servicios
{
    public class ServicioEmpleado : IServicioEmpleado
    {

        private readonly List<Empleado> listaEmpleados = new() {
        new Empleado{
            Id = 1, Nombre = "Juan", CodEmpleado= "A001", Edad = 25, Email="mail1@mail.es", FechaAlta=DateTime.Now, FechaBaja=null
        },
            new Empleado{
            Id = 1, Nombre = "Pedro", CodEmpleado= "A011", Edad = 65, Email="mail2@mail.es", FechaAlta=DateTime.Now, FechaBaja=null
        },
            new Empleado{
            Id = 1, Nombre = "Alfredo", CodEmpleado= "A021", Edad = 55, Email="mail3@mail.es", FechaAlta=DateTime.Now, FechaBaja=null
        },
            new Empleado{
            Id = 1, Nombre = "Pablo", CodEmpleado= "A031", Edad = 45, Email="mail4@mail.es", FechaAlta=DateTime.Now, FechaBaja=null
        },
            new Empleado{
            Id = 1, Nombre = "Ricardo", CodEmpleado= "A041", Edad = 57, Email="mail5@mail.es", FechaAlta=DateTime.Now, FechaBaja=null
        }
        };
        public IEnumerable<Empleado> DameEmpleados()
        {
            return listaEmpleados;
        }

        public Empleado DameEmpleado(string codEmpleado)
        {
            return listaEmpleados.Where(e => e.CodEmpleado == codEmpleado).SingleOrDefault();
        }

        public void NuevoEmpleado(Empleado e)
        {
            listaEmpleados.Add(e);
        }
        public void ModificarEmpleado(Empleado e)
        {
            int posicion = listaEmpleados.FindIndex(existeEmpleado => existeEmpleado.Id == e.Id);
            if (posicion != -1)
                listaEmpleados[posicion] = e;

        }
        public void BajaEmpleado(string codEmpleado)
        {
            int posicion = listaEmpleados.FindIndex(existeEmpleado => existeEmpleado.CodEmpleado == codEmpleado);
            if (posicion != -1)
                listaEmpleados.RemoveAt(posicion);
        }
    }

}
