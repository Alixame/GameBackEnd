using Microsoft.AspNetCore.Mvc;
using GameBackend.Models;

namespace GameBackend.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private DBGame db;

    public UserController(DBGame db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Index() 
    {
        return Ok(db.Users.ToList());
    }

    [HttpPost]
    public ActionResult Store(User newUser) 
    {
        db.Users.Add(newUser);
        db.SaveChanges();

        return Created(newUser.UserId.ToString(), newUser);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, User userForUpdate)
    {
        User? user = db.Users.Find(id);
        
        if (user == null) {
            return NotFound();
        }

        user.Name = userForUpdate.Name;
        user.Email = userForUpdate.Email;
        user.Password = userForUpdate.Password;

        db.SaveChanges();
        return Ok(user);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        User? user = db.Users.Find(id);
        
        if (user == null) {
            return NotFound();
        }

        db.Users.Remove(user);
        db.SaveChanges();
        return Ok(user);
    }
}
    