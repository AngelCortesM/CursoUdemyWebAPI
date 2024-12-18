﻿namespace CursoUdemyWebAPI.Servicios
{
    public interface IServicioEmpleadoSQL
    {
        public IEnumerable<Empleado> DameEmpleados();

        public Empleado DameEmpleado(string codEmpleado);

        public void NuevoEmpleado(Empleado e);

        public void ModificarEmpleado(Empleado e);

        public void BajaEmpleado(string codEmpleado);
    }
}