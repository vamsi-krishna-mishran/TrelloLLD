

public class Trello
{

    private static Trello _instance;
    public static Trello GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Trello();
        }
        return _instance;
    }


    private readonly BoardService _boardService;

    private readonly CardService _cardService;

    private readonly IdGeneratorService _idGeneratorService;

    private readonly ListService _listService;
    private readonly UserService _userService;

    private readonly LoggerService _loggerService;


    private Trello()
    {
        _boardService = new BoardService();
        _cardService = new CardService();
        _listService = new ListService();
        _idGeneratorService = new IdGeneratorService();
        _userService = new UserService();
        _loggerService = new LoggerService();

    }





    public Board CreateBoard(string boardName)
    {

        Board board = new Board();
        board.Name = boardName;
        board.Id = _idGeneratorService.GenerateId();
        board.Url = $"http://trello.com/board/{board.Id}";
        var result = _boardService.AddBoard(board);
        return result;
    }
    public Board RemoveBoard(Board board)
    {
        Board result = _boardService.RemoveBoard(board);
        return result;

    }
    public Board AddPeople(Board board, User user)
    {
        Board result = _boardService.AddMember(board, user);
        return result;
    }

    public Board RemovePeople(Board board, User user)
    {
        Board result = _boardService.RemoveMember(board, user);
        return result;

    }

    public User AddUser(string name, string email)
    {
        User user = new User();
        user.Id = _idGeneratorService.GenerateId();
        user.Email = email;
        user.Name = name;
        User result = _userService.AddUser(user);
        return result;
    }




    public BoardList AddList(string boardId, string Name)
    {
        Board board = _boardService.GetBoard(boardId);
        if (board is null)
        {
            _loggerService.Error($"board id {boardId} is not present.");
            return null;
        }
        BoardList boardList = new BoardList();
        boardList.Name = Name;
        boardList.Board = board;
        BoardList result = _listService.AddList(boardList);
        return result;
    }
}