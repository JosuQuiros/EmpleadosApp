using Dapper;
using Microsoft.Data.SqlClient;

public class EmpleadoRepository
{
	private readonly string _connectionString;

	public EmpleadoRepository(IConfiguration config)
	{
		_connectionString = config.GetConnectionString("DefaultConnection");
	}

	public IEnumerable<Empleado> GetEmpleados()
	{
		using var connection = new SqlConnection(_connectionString);
		return connection.Query<Empleado>("sp_GetEmpleados", commandType: System.Data.CommandType.StoredProcedure);
	}

	public int InsertEmpleado(string nombre, decimal salario)
	{
		using var connection = new SqlConnection(_connectionString);
		var parameters = new { Nombre = nombre, Salario = salario };
		return connection.Execute("sp_InsertEmpleado", parameters, commandType: System.Data.CommandType.StoredProcedure);
	}
}
