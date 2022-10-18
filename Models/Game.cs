namespace GameBackend.Models;

public class Game
{
    // Atributos
    private int gameId; // uuid

    private string name;

    private bool status;

    // Propriedades (Com a propriedades não é necessario criar metodos  GET/SET)
    public int GameId 
    {
        get { return gameId; }
        set { gameId = value; }
    }

    public string Name 
    {
        get { return name; }
        set { name = value; }
    }

    public bool Status 
    {
        get { return status; }
        set { status = value; }
    }

    public int UserId { get; set; }

    public User? User { get; set; }
    public List<Quiz>? Quizzes { get; set; }
}