///List: Each list should have a id, name and cards
///


public class BoardList
{
    public string Id { get; set; }

    public Board Board { get; set; }

    public string Name { get; set; }


    public override string ToString()
    {
        return $"(Id:{Id},BoardId:{Board.Id},Name:{Name})\n";
    }





}