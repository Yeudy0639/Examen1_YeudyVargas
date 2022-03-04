using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
namespace WebApp.Pages.Parametros
{
public class GridModel : PageModel
{
private readonly IParametrosService ParametrosServices;



public GridModel(IParametrosService ProveedorService)
{
this.ParametrosServices = ProveedorService;
}



public IEnumerable<ParametrosEntity> GridList { get; set; } = new List<ParametrosEntity>();



public string Mensaje { get; set; } = "";



public async Task<IActionResult> OnGet()
{
try
{
GridList = await ParametrosServices.Get();



if (TempData.ContainsKey("Msg"))
{
Mensaje = TempData["Msg"] as string;
}



TempData.Clear();



return Page();
}
catch (Exception ex)
{



return Content(ex.Message);
}
}




public async Task<IActionResult> OnGetEliminar(int id)
{
try
{
var result = await ParametrosServices.Delete(new()
{
Id_Parametro = id
}
);



if (result.CodeError != 0)
{
throw new Exception(result.MsgError);
}



TempData["Msg"] = "El registro se elimino correctamente";



return Redirect("Grid");
}
catch (Exception ex)
{



return Content(ex.Message);
}
}
}
}
