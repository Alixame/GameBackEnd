using Microsoft.AspNetCore.Mvc;
using GameBackend.Models;

namespace GameBackend.Controllers;

[ApiController]
[Route("game")]
public class GameController : ControllerBase
{
    static List<Game> listGame = new List<Game>();

    [HttpGet]
    public ActionResult Index() 
    {
        return Ok(listGame);
    }

    [HttpPost]
    public ActionResult Store(Game newGame) 
    {
        newGame.GameId = Guid.NewGuid();

        listGame.Add(newGame);

        return Created(newGame.GameId.ToString(), newGame);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(Guid id, Game gameForUpdate)
    {
        foreach (Game game in listGame)
        {
            if (game.GameId == id)
            {
                game.Name = gameForUpdate.Name;
                game.Status = gameForUpdate.Status;
            }
        }
        return NotFound();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(Guid id)
    {
        foreach (Game game in listGame)
        {
            if (game.GameId == id)
            {
                listGame.Remove(game);
                return Ok($"Apagou o id: {id}");
            }
        }
        return NotFound();
    }
}
    