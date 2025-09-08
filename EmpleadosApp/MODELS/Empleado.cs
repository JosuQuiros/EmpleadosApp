using System.ComponentModel.DataAnnotations;

public class Empleado
{
	public int Id { get; set; }

	[Required(ErrorMessage = "No puede ser dejado en blanco")]
	[RegularExpression(@"^[a-zA-Z\s\-]+$", ErrorMessage = "Solo letras y guiones.")]
	public string Nombre { get; set; }

	[Required(ErrorMessage = "No puede ser dejado en blanco")]
	[Range(0.01, double.MaxValue, ErrorMessage = "El salario debe ser un numero positivo.")]
	public decimal Salario { get; set; }
}
