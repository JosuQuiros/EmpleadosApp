using Microsoft.AspNetCore.Mvc;

public class EmpleadoController : Controller
{
	private readonly EmpleadoRepository _repo;

	public EmpleadoController(IConfiguration config)
	{
		_repo = new EmpleadoRepository(config);
	}

	public IActionResult Index()
	{
		var empleados = _repo.GetEmpleados();
		return View(empleados);
	}

	[HttpGet]
	public IActionResult Insert()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Insert(Empleado empleado)
	{
		if (!ModelState.IsValid)
			return View(empleado);

		try
		{
			_repo.InsertEmpleado(empleado.Nombre, empleado.Salario);
			TempData["Mensaje"] = "Inserción exitosa.";
			return RedirectToAction("Index");
		}
		catch
		{
			ModelState.AddModelError("", "El nombre de empleado ya existe.");
			return View(empleado);
		}
	}
}
