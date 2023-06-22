namespace JokesWebApp.Models;

public class Joke
{
    public Joke()
    {
        
    }

    public int ID { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}