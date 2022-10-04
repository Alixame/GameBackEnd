using Microsoft.AspNetCore.Mvc;
using GameBackend.Models;

namespace GameBackend.Controllers;

[ApiController]
[Route("quiz")]
public class QuizController : ControllerBase
{
    private DBGame db;

    public QuizController(DBGame db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Index() 
    {
        return Ok(db.Quizzes.ToList());
    }

    [HttpPost]
    public ActionResult Store(Quiz newQuiz) 
    {
        db.Quizzes.Add(newQuiz);
        db.SaveChanges();

        return Created(newQuiz.QuizId.ToString(), newQuiz);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, Quiz quizForUpdate)
    {
        Quiz? quiz = db.Quizzes.Find(id);
        
        if (quiz == null) {
            return NotFound();
        }

        quiz.Question = quizForUpdate.Question;
        quiz.Option1 = quizForUpdate.Option1;
        quiz.Option2 = quizForUpdate.Option2;
        quiz.Option3 = quizForUpdate.Option3;
        quiz.Option4 = quizForUpdate.Option4;
        quiz.Correct = quizForUpdate.Correct;

        db.SaveChanges();
        return Ok(quiz);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        Quiz? quiz = db.Quizzes.Find(id);
        
        if (quiz == null) {
            return NotFound();
        }

        db.Quizzes.Remove(quiz);
        db.SaveChanges();
        return Ok(quiz);
    }
}
    