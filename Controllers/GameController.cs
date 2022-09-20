using Microsoft.AspNetCore.Mvc;
using GameBackend.Models;

namespace GameBackend.Controllers;

[ApiController]
[Route("game")]
public class GameController : ControllerBase
{
    List<Game> lista = new List<Game>();

    [HttpGet]
    public ActionResult Get() 
    {
        Game g1 = new Game();
        g1.GameId = 1;
        g1.Name = "Lucas Lindao";
        g1.Status = true;

        lista.Add(g1);

        return Ok(lista);
    }

    [HttpPost]
    public ActionResult Post() 
    {
        return Ok("game criado");
    }
}
    