

using System.Net;

///Card: Each card should have a id, name, description, assigned user
///
public class Card
{

    public string Id { get; set; }

    public BoardList BoardList { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public User AssignedUser { get; set; }

    public override string ToString()
    {
        return $"( Id:{Id}, BoardList:{BoardList}, Name:{Name}, Description:{Description}, AssignedUser:{AssignedUser})";
    }
}