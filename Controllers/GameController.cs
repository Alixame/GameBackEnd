using Microsoft.AspNetCore.Mvc;
using GameBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameBackend.Controllers;

[ApiController]
[Route("game")]
public class GameController : ControllerBase
{
    //static List<Game> listGames = new List<Game>();

    private DBGame db;

    public GameController(DBGame db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Index() 
    {
        return Ok(db.Games.Include(g => g.User).Include(g => g.Quizzes).ToList());
    }

    [HttpPost]
    public ActionResult Store(Game newGame) 
    {
        db.Games.Add(newGame);
        db.SaveChanges();

        return Created(newGame.GameId.ToString(), newGame);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, Game gameForUpdate)
    {
        Game? game = db.Games.Find(id);
        
        if (game == null) {
            return NotFound();
        }

        game.Name = gameForUpdate.Name;
        game.Status = gameForUpdate.Status;

        db.SaveChanges();
        return Ok(game);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        Game? game = db.Games.Find(id);
        
        if (game == null) {
            return NotFound();
        }

        db.Games.Remove(game);
        db.SaveChanges();
        return Ok(game);
    }
}
    