namespace trello;

class Program
{
    static void Main(string[] args)
    {
        Trello trello = Trello.GetInstance();


        Board board = trello.CreateBoard("work@tech");
        User user = trello.AddUser("vamiskrishna", "vamis@gmail.com");
        trello.AddPeople(board, user);

        BoardList list = trello.AddList("vamsi", "Mock interviews");

        Console.WriteLine(board);

    }
}
