


public class Database
{

    private static Database _database;

    public Dictionary<string, Board> Boards;

    public Dictionary<string, Card> Cards;

    public Dictionary<string, BoardList> Lists;

    public Dictionary<string, User> Users;
    private Database()
    {
        this.Boards = new();
        this.Lists = new();
        this.Cards = new();
        this.Users = new();
    }


    public static Database GetInstance()
    {
        if (_database == null)
        {
            _database = new Database();
        }
        return _database;
    }




}