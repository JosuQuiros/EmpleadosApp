using System.ComponentModel.DataAnnotations;

public class Empleado
{
	public int Id { get; set; }

	[Required]
	[RegularExpression(@"^[a-zA-Z\s\-]+$", ErrorMessage = "Solo letras y guiones.")]
	public string Nombre { get; set; }

	[Required]
	[Range(0.01, double.MaxValue, ErrorMessage = "El salario debe ser positivo.")]
	public decimal Salario { get; set; }
}
