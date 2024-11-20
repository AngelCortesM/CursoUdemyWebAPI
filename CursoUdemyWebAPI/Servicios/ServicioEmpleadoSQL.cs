using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CursoUdemyWebAPI.Servicios
{
    public class ServicioEmpleadoSQL : IServicioEmpleadoSQL
    {
        private string CadenaConexion;

        public ServicioEmpleadoSQL(ConexionBaseDatos conex)
        {
            CadenaConexion = conex.CadenaConexionSQL;
        }

        private SqlConnection conexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        public void BajaEmpleado(string codEmpleado)
        {
            throw new NotImplementedException();
        }

        public Empleado DameEmpleado(string codEmpleado)
        {
            SqlConnection sqlConexion = conexion();
            Empleado e = null;
            try
            {
                sqlConexion.Open();
                var param = new DynamicParameters();

                param.Add("@CodEmpleado", codEmpleado, DbType.String, ParameterDirection.Input, 4);

                e = sqlConexion.QueryFirstOrDefault<Empleado>("EmpleadoObtener", param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al obtener el empleado" + ex.Message);
            }
            finally
            {
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
            return e;
        }

        public IEnumerable<Empleado> DameEmpleados()
        {
            SqlConnection sqlConexion = conexion();
            List<Empleado> empleados = new List<Empleado>();
            try
            {
                sqlConexion.Open();

                var r = sqlConexion.Query<Empleado>("EmpleadoObtener", commandType: CommandType.StoredProcedure);
                empleados = r.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al obtener los empleados\"" + ex.Message);
            }
            finally
            {
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
            return empleados;
        }

        public void ModificarEmpleado(Empleado e)
        {
            throw new NotImplementedException();
        }

        public void NuevoEmpleado(Empleado e)
        {
            SqlConnection sqlConexion = conexion();
            try
            {
                sqlConexion.Open();
                var param = new DynamicParameters();
                param.Add("@Nombre", e.Nombre, DbType.String, ParameterDirection.Input, 500);
                param.Add("@CodEmpleado", e.CodEmpleado, DbType.String, ParameterDirection.Input, 4);
                param.Add("@Email", e.Email, DbType.String, ParameterDirection.Input, 254);
                param.Add("@Edad", e.Edad, DbType.Int32, ParameterDirection.Input);
                param.Add("@FechaAlta", e.FechaAlta, DbType.DateTime, ParameterDirection.Input);
                sqlConexion.ExecuteScalar("EmpleadoAlta", param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al dar de alta" + ex.Message);
            }
            finally
            {
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
        }
    }
}