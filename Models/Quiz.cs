namespace GameBackend.Models;

public class Quiz
{
    // PROPRIEDADES AUTOMATICAS
    public int QuizId { get; set; }
    public int GameId { get; set; }
    public string Question { get; set; }
    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public string Option3 { get; set; }
    public string Option4 { get; set; }
    public int Correct { get; set; }
}